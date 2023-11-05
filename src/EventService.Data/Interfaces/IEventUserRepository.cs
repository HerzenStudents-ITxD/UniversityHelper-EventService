using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser.Filter;
using HerzenHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Data.Interfaces;

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
