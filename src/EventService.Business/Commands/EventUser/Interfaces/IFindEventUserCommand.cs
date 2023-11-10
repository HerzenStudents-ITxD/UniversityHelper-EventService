using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser.Filter;
using UniversityHelper.Core.Responses;
using System.Threading.Tasks;
using System.Threading;
using System;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Business.Commands.EventUser.Interfaces;

[AutoInject]
public interface IFindEventUserCommand
{
  Task<FindResultResponse<EventUserInfo>> ExecuteAsync(
    Guid eventId,
    FindEventUsersFilter filter,
    CancellationToken cancellationToken = default);
}
