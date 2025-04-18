﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Data.Provider;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace UniversityHelper.EventService.Data;

public class EventRepository : IEventRepository
{
  private readonly IDataProvider _provider;

  private async Task<(List<DbEvent>, int totalCount)> CreateFindPredicate(FindEventsFilter filter, CancellationToken ct)
  {
    IQueryable<DbEvent> query = _provider.Events.Include(e => e.EventsCategories).AsNoTracking();

    if (!filter.IncludeDeactivated)
    {
      query = query.Where(p => p.IsActive);
    }

    if (!string.IsNullOrWhiteSpace(filter.NameIncludeSubstring))
    {
      query = query.Where(p =>
        p.Name.Contains(filter.NameIncludeSubstring) ||
        p.Description.Contains(filter.NameIncludeSubstring)).OrderByDescending(p => p.Date);
    }

    if (!string.IsNullOrWhiteSpace(filter.CategoryNameIncludeSubstring))
    {
      query = query.Where(p =>
        p.EventsCategories.Where(ec => ec.Category.Name.Contains(filter.CategoryNameIncludeSubstring)).Any()).OrderByDescending(p => p.Date);
    }

    if (filter.Color.HasValue)
    {
      query = query.Where(p =>
        p.EventsCategories.Any(ec => ec.Category.Color == filter.Color.Value)).OrderByDescending(p => p.Date);
    }

    if (filter.Access.HasValue)
    {
      query = query.Where(p => p.Access == filter.Access.Value);
    }

    if (filter.UserId.HasValue)
    {
      query = query.Where(p =>
        p.Users.Any(u => u.Id == filter.UserId.Value)).OrderByDescending(p => p.Date);
    }

    if (filter.StartTime.HasValue)
    {
      query = query.Where(p => p.Date >= filter.StartTime.Value);
    }

    if (filter.EndTime.HasValue)
    {
      query = query.Where(p => p.Date <= filter.EndTime.Value);
    }

    return (
      await query
        .Skip(filter.SkipCount)
        .Take(filter.TakeCount)
        .ToListAsync(ct),
      await query.CountAsync(ct));
  }

  private Task<DbEvent> CreateGetPredicate(GetEventFilter filter)
  {
    IQueryable<DbEvent> query = _provider.Events.AsNoTracking();

    if (filter.IncludeCategories)
    {
      query = query.Include(e => e.EventsCategories);
    }

    if (filter.IncludeUsers)
    {
      query = query.Include(e => e.Users);
    }

    if (filter.IncludeImages)
    {
      query = query.Include(e => e.Images);
    }

    if (filter.IncludeFiles)
    {
      query = query.Include(e => e.Files);
    }

    if (filter.IncludeComments)
    {
      query = query.Include(e => e.Comments.OrderBy(c => c.CreatedAtUtc));
    }

    return query.FirstOrDefaultAsync(e => e.Id == filter.EventId);
  }

  public EventRepository(
    IDataProvider provider)
  {
    _provider = provider;
  }

  public async Task<Guid?> CreateAsync(DbEvent dbEvent)
  {
    if (dbEvent is null)
    {
      return null;
    }

    _provider.Events.Add(dbEvent);
    _provider.EventsUsers.AddRange(dbEvent.Users);

    if (!dbEvent.EventsCategories.IsNullOrEmpty())
    {
      _provider.EventsCategories.AddRange(dbEvent.EventsCategories);
    }

    await _provider.SaveAsync();

    return dbEvent.Id;
  }

  public async Task<bool> EditAsync(Guid eventId, Guid senderId, JsonPatchDocument<DbEvent> request)
  {
    DbEvent dbEvent = await _provider.Events.Include(e => e.Comments).FirstOrDefaultAsync(x => x.Id == eventId);

    if (dbEvent is null || request is null)
    {
      return false;
    }

    bool oldIsActive = dbEvent.IsActive;

    request.ApplyTo(dbEvent);
    dbEvent.ModifiedBy = senderId;
    dbEvent.ModifiedAtUtc = DateTime.UtcNow;

    bool newIsActive = dbEvent.IsActive;

    if (oldIsActive != newIsActive)
    {
      IEnumerable<DbEventComment> comments = dbEvent.Comments
        .Where(x => x.EventId == eventId && (x.Content != null));

      foreach (DbEventComment comment in comments)
      {
        comment.IsActive = newIsActive;
        comment.ModifiedBy = senderId;
        comment.ModifiedAtUtc = DateTime.UtcNow;
      }
    }

    await _provider.SaveAsync();

    return true;
  }

  public Task<bool> DoesExistAsync(Guid eventId, bool? isActive)
  {
    if (isActive is not null)
    {
      return _provider.Events.AnyAsync(e => e.Id == eventId && e.IsActive);
    }
    else
    {
      return _provider.Events.AnyAsync(e => e.Id == eventId);
    }
  }

  public async Task<bool> IsEventCompletedAsync(Guid eventId)
  {
    DbEvent dbEvent = await _provider.Events.FirstOrDefaultAsync(x => x.Id == eventId);

    if (!dbEvent.IsActive ||
         dbEvent.IsActive &&
            (dbEvent.EndDate is null && dbEvent.Date > DateTime.UtcNow  ||
            dbEvent.EndDate > DateTime.UtcNow))
    {
      return true;
    }

    return false;
  }

  public Task<List<Guid>> GetExisting(List<Guid> eventsIds)
  {
    return _provider.Events.AsNoTracking().Where(p => eventsIds.Contains(p.Id)).Select(p => p.Id).ToListAsync();
  }

  public Task<DbEvent> GetAsync(
    Guid eventId,
    GetEventFilter filter = null)
  {
    if (filter is null)
    {
      return _provider.Events.AsNoTracking().FirstOrDefaultAsync(e => e.Id == eventId);
    }

    return CreateGetPredicate(filter);
  }

  public async Task<(List<DbEvent>, int totalCount)> FindAsync(FindEventsFilter filter, CancellationToken ct)
  {
    if (filter is null)
    {
      return default;
    }

    return await CreateFindPredicate(filter, ct);
  }

  public Task<DbEvent> GetAsync(Guid eventId)
  {
    return _provider.Events.AsNoTracking().FirstOrDefaultAsync(e => e.Id == eventId);
  }

  public async Task<(List<Guid> filesIds, List<Guid> imagesIds)> RemoveDataAsync(Guid eventId)
  {
    DbEvent dbEvent = await _provider.Events
      .Include(e => e.Users)
      .Include(e => e.Files)
      .Include(e => e.Images)
      .Include(e => e.Comments)
        .ThenInclude(c => c.Images)
      .Include(e => e.Comments)
        .ThenInclude(c => c.Files)
      .FirstOrDefaultAsync(p => p.Id == eventId);

    List<Guid> filesIds = dbEvent.Files.Select(file => file.FileId).ToList();
    List<Guid> imagesIds = dbEvent.Images.Select(image => image.ImageId).ToList();
    List<DbEventComment> comments = dbEvent.Comments
       .Where(x => x.EventId == eventId && (x.Content != null)).ToList();

    foreach (DbEventComment comment in comments)
    {
      filesIds.AddRange(comment.Files.Select(f => f.FileId));
      imagesIds.AddRange(comment.Images.Select(f => f.ImageId));

      _provider.Images.RemoveRange(comment.Images);
      _provider.Files.RemoveRange(comment.Files);
    }

    _provider.EventsUsers.RemoveRange(dbEvent.Users);

    _provider.Images.RemoveRange(dbEvent.Images);

    _provider.Files.RemoveRange(dbEvent.Files);

    await _provider.SaveAsync();

    return (filesIds, imagesIds);
  }
}
