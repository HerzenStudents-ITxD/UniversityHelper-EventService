using System;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.EventService.Models.Dto.Responses.Event;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.Event.Interfaces;

[AutoInject]
public interface IGetEventCommand
{
  Task<OperationResultResponse<EventResponse>> ExecuteAsync(GetEventFilter filter, CancellationToken ct);
}
