using System;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.Event.Interfaces;

[AutoInject]
public interface ICreateEventCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateEventRequest request);
}
