using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser.Filter;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Data.Interfaces;

[AutoInject]
public interface IEventUserRepository
{
  Task<bool> DoesExistAsync(List<Guid> userId, Guid eventId);
  Task<bool> DoesExistAsync(Guid eventUserId);
  Task<bool> CreateAsync(List<DbEventUser> dbEventUsers);
  Task<List<DbEventUser>> FindAsync(
    Guid eventId, 
    FindEventUsersFilter filter, 
    CancellationToken cancellationToken);
  Task<DbEventUser> GetAsync(Guid eventUserId);
  Task<bool> EditAsync(Guid eventUserId, JsonPatchDocument<DbEventUser> request);
}
