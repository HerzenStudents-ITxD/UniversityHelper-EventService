﻿using System;
using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Business.Commands.Event.Interfaces;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.Event;
using HerzenHelper.EventService.Models.Dto.Responses.Event;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.EventService.Controllers;

[Route("[controller]")]
[ApiController]
public class EventController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateEventCommand command,
    [FromBody] CreateEventRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpGet("find")]
  public async Task<FindResultResponse<EventInfo>> FindAsync(
    [FromServices] IFindEventsCommand command,
    [FromQuery] FindEventsFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }

  [HttpGet("get")]
  public async Task<OperationResultResponse<EventResponse>> GetAsync(
    [FromServices] IGetEventCommand command,
    [FromQuery] GetEventFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter, ct);
  }

  [HttpPatch("edit")]
  public async Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditEventCommand command,
    [FromQuery] Guid eventId,
    [FromBody] JsonPatchDocument<EditEventRequest> request)
  {
    return await command.ExecuteAsync(eventId, request);
  }
}
