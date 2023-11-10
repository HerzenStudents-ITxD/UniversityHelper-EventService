using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Business.Commands.Event.Interfaces;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Mappers.Models.Interface;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Constants;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.Http;

namespace UniversityHelper.EventService.Business.Commands.Event;

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
