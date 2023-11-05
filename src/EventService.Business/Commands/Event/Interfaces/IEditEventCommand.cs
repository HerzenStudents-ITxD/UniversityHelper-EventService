using System;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.Event;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Business.Commands.Event.Interfaces;

[AutoInject]
public interface IEditEventCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid eventId, JsonPatchDocument<EditEventRequest> patch);
}
