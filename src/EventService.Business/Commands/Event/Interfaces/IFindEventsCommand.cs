using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.Event.Interfaces;

[AutoInject]
public interface IFindEventsCommand
{
  Task<FindResultResponse<EventInfo>> ExecuteAsync(
    FindEventsFilter filter,
    CancellationToken ct = default);
}
