using UniversityHelper.Core.Responses;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityHelper.EventService.Models.Dto.Requests.EventComment;
using System;
using UniversityHelper.EventService.Business.Commands.EventComment.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Controllers;

[Route("[controller]")]
[ApiController]
public class EventCommentController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateAsync(
    [FromServices] ICreateEventCommentCommand command,
    [FromBody] CreateEventCommentRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpPatch("edit")]
  public Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditEventCommentCommand command,
    [FromQuery] Guid commentId,
    [FromBody] JsonPatchDocument<EditEventCommentRequest> request)
  {
    return command.ExecuteAsync(commentId, request);
  }
}
