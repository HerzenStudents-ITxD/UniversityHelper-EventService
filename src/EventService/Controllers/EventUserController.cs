using System;
using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Business.Commands.EventUser.Interfaces;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser.Filter;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.EventService.Controllers;

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
