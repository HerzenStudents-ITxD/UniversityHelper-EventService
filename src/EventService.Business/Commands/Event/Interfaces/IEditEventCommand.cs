using System;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Business.Commands.Event.Interfaces;

[AutoInject]
public interface IEditEventCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid eventId, JsonPatchDocument<EditEventRequest> patch);
}
