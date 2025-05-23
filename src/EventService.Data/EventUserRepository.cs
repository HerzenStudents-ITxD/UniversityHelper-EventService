﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Data.Provider;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser.Filter;
using UniversityHelper.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.EventService.Data;

public class EventUserRepository : IEventUserRepository
{
  private readonly IDataProvider _provider;
  private readonly IHttpContextAccessor _httpContextAccessor;

  public EventUserRepository(
    IDataProvider provider,
    IHttpContextAccessor httpContextAccessor)
  {
    _provider = provider;
    _httpContextAccessor = httpContextAccessor;
  }

  public Task<bool> DoesExistAsync(List<Guid> userId, Guid eventId)
  {
    return _provider.EventsUsers.AsNoTracking().AnyAsync(eu => userId.Contains(eu.UserId) && eu.EventId == eventId);
  }

  public Task<bool> DoesExistAsync(Guid eventUserId)
  {
    return _provider.EventsUsers.AsNoTracking().AnyAsync(eu => eu.Id == eventUserId);
  }

  public async Task<bool> CreateAsync(List<DbEventUser> dbEventUsers)
  {
    if (dbEventUsers is null)
    {
      return false;
    }

    _provider.EventsUsers.AddRange(dbEventUsers);
    await _provider.SaveAsync();

    return true;
  }

  public Task<List<DbEventUser>> FindAsync(
    Guid eventId,
    FindEventUsersFilter filter,
    CancellationToken cancellationToken)
  {
    IQueryable<DbEventUser> eventUsersQuery = _provider.EventsUsers.AsNoTracking().Where(eu =>
      eu.EventId == eventId);

    if (filter.Status.HasValue)
    {
      eventUsersQuery = eventUsersQuery.Where(s => s.Status == filter.Status);
    }

    return eventUsersQuery.ToListAsync(cancellationToken: cancellationToken);
  }

  public Task<DbEventUser> GetAsync(Guid eventUserId)
  {
    return _provider.EventsUsers.AsNoTracking().FirstOrDefaultAsync(eu => eu.Id == eventUserId);
  }

  public async Task<bool> EditAsync(Guid eventUserId, JsonPatchDocument<DbEventUser> request)
  {
    DbEventUser dbEventUser = await _provider.EventsUsers.FirstOrDefaultAsync(x => x.Id == eventUserId);

    if (dbEventUser is null || request is null)
    {
      return false;
    }
    
    request.ApplyTo(dbEventUser);
    dbEventUser.ModifiedBy = _httpContextAccessor.HttpContext.GetUserId();
    dbEventUser.ModifiedAtUtc = DateTime.UtcNow;

    await _provider.SaveAsync();

    return true;
  }
}
