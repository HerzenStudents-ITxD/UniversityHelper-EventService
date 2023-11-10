using System;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Business.Commands.EventUser.Interfaces;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser.Filter;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.EventService.Controllers;

[Route("[controller]")]
[ApiController]
public class EventUserController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<bool>> CreateAsync(
    [FromServices] ICreateEventUserCommand command,
    [FromBody] CreateEventUserRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet("find")]
  public async Task<FindResultResponse<EventUserInfo>> FindAsync(
    [FromServices] IFindEventUserCommand command,
    [FromQuery] Guid eventId,
    [FromQuery] FindEventUsersFilter filter,
    CancellationToken cancellationToken)
  {
    return await command.ExecuteAsync(eventId: eventId, filter: filter, cancellationToken: cancellationToken);
  }

  [HttpPatch("edit")]
  public Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditEventUserCommand command,
    [FromQuery] Guid eventUserId,
    [FromBody] JsonPatchDocument<EditEventUserRequest> request)
  {
    return command.ExecuteAsync(eventUserId, request);
  }
}
