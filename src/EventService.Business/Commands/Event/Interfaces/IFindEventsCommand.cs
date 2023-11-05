using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.Event;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.Event.Interfaces;

[AutoInject]
public interface IFindEventsCommand
{
  Task<FindResultResponse<EventInfo>> ExecuteAsync(
    FindEventsFilter filter,
    CancellationToken ct = default);
}
