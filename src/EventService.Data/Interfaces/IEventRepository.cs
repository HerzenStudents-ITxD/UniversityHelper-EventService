﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Data.Interfaces;

[AutoInject]
public interface IEventRepository
{
  Task<Guid?> CreateAsync(DbEvent dbEvent);
  Task<bool> EditAsync(Guid eventId, Guid senderId, JsonPatchDocument<DbEvent> request);
  Task<bool> DoesExistAsync(Guid eventId, bool? isActive);
  Task<bool> IsEventCompletedAsync(Guid eventId);
  Task<List<Guid>> GetExisting(List<Guid> eventsIds);
  Task<DbEvent> GetAsync(Guid eventId, GetEventFilter filter = null);
  Task<(List<DbEvent>, int totalCount)> FindAsync(
    FindEventsFilter filter,
    CancellationToken ct);
  Task<DbEvent> GetAsync(Guid eventId);
  Task<(List<Guid> filesIds, List<Guid> imagesIds)> RemoveDataAsync(Guid eventId);
}
