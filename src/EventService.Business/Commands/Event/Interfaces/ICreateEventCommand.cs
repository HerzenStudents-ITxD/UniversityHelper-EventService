using System;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.Event;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.Event.Interfaces;

[AutoInject]
public interface ICreateEventCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateEventRequest request);
}
