using System.Collections.Generic;
using System.Linq;
using UniversityHelper.Models.Broker.Models.User;
using UniversityHelper.EventService.Mappers.Models.Interfaces;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Responses.Event;
using UniversityHelper.Models.Broker.Models.File;

namespace UniversityHelper.EventService.Mappers.Models;

public class EventResponseMapper : IEventResponseMapper
{
  private readonly ICategoryInfoMapper _categoryInfoMapper;
  private readonly IUserInfoMapper _userInfoMapper;

  public EventResponseMapper(
    ICategoryInfoMapper categoryInfoMapper,
    IUserInfoMapper userInfoMapper)
  {
    _categoryInfoMapper = categoryInfoMapper;
    _userInfoMapper = userInfoMapper;
  }

  public EventResponse Map(
    DbEvent dbEvent,
    List<UserData> usersData)
  {
    return dbEvent is null
      ? null
      : new EventResponse
      {
        Id = dbEvent.Id,
        Name = dbEvent.Name,
        Address = dbEvent.Address,
        Description = dbEvent.Description,
        Date = dbEvent.Date,
        Format = dbEvent.Format,
        Access = dbEvent.Access,
        CreatedAtUtc = dbEvent.CreatedAtUtc,
        EventCategories = dbEvent.EventsCategories.Any()
          ? dbEvent.EventsCategories?.Select(ec => _categoryInfoMapper.Map(ec.Category)).ToList()
          : null,
        EventUsers = _userInfoMapper.Map(usersData)
      };
  }
}
