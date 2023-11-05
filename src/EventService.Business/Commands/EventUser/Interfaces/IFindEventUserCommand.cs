using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser.Filter;
using HerzenHelper.Core.Responses;
using System.Threading.Tasks;
using System.Threading;
using System;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Business.Commands.EventUser.Interfaces;

[AutoInject]
public interface IFindEventUserCommand
{
  Task<FindResultResponse<EventUserInfo>> ExecuteAsync(
    Guid eventId,
    FindEventUsersFilter filter,
    CancellationToken cancellationToken = default);
}
