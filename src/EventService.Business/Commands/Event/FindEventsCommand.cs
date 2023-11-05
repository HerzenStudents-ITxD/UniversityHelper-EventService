using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Business.Commands.Event.Interfaces;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.EventService.Mappers.Models.Interface;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.Event;
using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using HerzenHelper.Core.Constants;
using HerzenHelper.Core.Extensions;
using HerzenHelper.Core.Helpers.Interfaces;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.Http;

namespace HerzenHelper.EventService.Business.Commands.Event;

public class FindEventsCommand : IFindEventsCommand
{
  private readonly IEventRepository _repository;
  private readonly IEventInfoMapper _mapper;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly IHttpContextAccessor _contextAccessor;

  public FindEventsCommand(
    IEventRepository repository,
    IEventInfoMapper mapper,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    IHttpContextAccessor contextAccessor)
  {
    _repository = repository;
    _mapper = mapper;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _contextAccessor = contextAccessor;
  }

  public async Task<FindResultResponse<EventInfo>> ExecuteAsync(FindEventsFilter filter, CancellationToken ct = default)
  {
    if (filter.IncludeDeactivated &&
      !await _accessValidator.HasRightsAsync(_contextAccessor.HttpContext.GetUserId(), Rights.AddEditRemoveUsers))
    {
      return _responseCreator.CreateFailureFindResponse<EventInfo>(HttpStatusCode.Forbidden);
    }

    (List<DbEvent> events, int totalCount) =
      await _repository.FindAsync(filter, ct);

    if (events is null || !events.Any())
    {
      return new();
    }

    return new FindResultResponse<EventInfo>
    {
      Body = events.ConvertAll(_mapper.Map),
      TotalCount = totalCount
    };
  }
}
