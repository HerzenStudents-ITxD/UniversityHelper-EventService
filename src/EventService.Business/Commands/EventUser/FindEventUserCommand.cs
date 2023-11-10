using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.Models.Broker.Models.User;
using UniversityHelper.EventService.Broker.Requests.Interfaces;
using UniversityHelper.EventService.Business.Commands.EventUser.Interfaces;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Mappers.Models.Interface;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser.Filter;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.EventUser;

public class FindEventUserCommand : IFindEventUserCommand
{
  private readonly IEventUserRepository _eventUserRepository;
  private readonly IEventRepository _eventRepository;
  private readonly IUserService _userService;
  private readonly IEventUserInfoMapper _eventUserInfoMapper;
  private readonly IUserInfoMapper _userInfoMapper;
  private readonly IResponseCreator _responseCreator;

  public FindEventUserCommand(
    IEventUserRepository eventUserRepository,
    IEventRepository eventRepository,
    IUserService userService,
    IEventUserInfoMapper eventUserInfoMapper,
    IUserInfoMapper userInfoMapper,
    IResponseCreator responseCreator)
  {
    _eventUserRepository = eventUserRepository;
    _eventRepository = eventRepository;
    _userService = userService;
    _eventUserInfoMapper = eventUserInfoMapper;
    _userInfoMapper = userInfoMapper;
    _responseCreator = responseCreator;
  }

  public async Task<FindResultResponse<EventUserInfo>> ExecuteAsync(
    Guid eventId,
    FindEventUsersFilter filter,
    CancellationToken cancellationToken)
  {
    if (!await _eventRepository.DoesExistAsync(eventId, true))
    {
      return _responseCreator.CreateFailureFindResponse<EventUserInfo>(HttpStatusCode.NotFound);
    }

    List<DbEventUser> eventUsers =
      await _eventUserRepository.FindAsync(eventId: eventId, filter: filter, cancellationToken: cancellationToken);

    if (eventUsers is null || !eventUsers.Any())
    {
      return new();
    }

    (List<UserData> usersData, int totalCount) = await _userService.FilteredUsersDataAsync(
      usersIds:eventUsers.Select(e => e.UserId).ToList(),
      skipCount: filter.SkipCount,
      takeCount: filter.TakeCount,
      ascendingSort: filter.IsAscendingSort,
      fullNameIncludeSubstring: filter.UserFullNameIncludeSubstring);

    return new FindResultResponse<EventUserInfo>(
      totalCount: totalCount,
      body: _eventUserInfoMapper.Map(
        userInfos: _userInfoMapper.Map(usersData),
        eventUsers: eventUsers));
  }
}
