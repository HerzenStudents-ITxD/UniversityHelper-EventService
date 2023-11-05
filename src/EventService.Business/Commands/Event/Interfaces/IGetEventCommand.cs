using System;
using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.Event;
using HerzenHelper.EventService.Models.Dto.Responses.Event;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.Event.Interfaces;

[AutoInject]
public interface IGetEventCommand
{
  Task<OperationResultResponse<EventResponse>> ExecuteAsync(GetEventFilter filter, CancellationToken ct);
}
