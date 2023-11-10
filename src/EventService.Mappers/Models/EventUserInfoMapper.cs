using System.Collections.Generic;
using System.Linq;
using UniversityHelper.EventService.Mappers.Models.Interface;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;

namespace UniversityHelper.EventService.Mappers.Models;

public class EventUserInfoMapper : IEventUserInfoMapper
{
  public List<EventUserInfo> Map(List<UserInfo> userInfos, List<DbEventUser> eventUsers)
  {
    return eventUsers?.Select(eu => new EventUserInfo
    {
      Id = eu.Id,
      Status = eu.Status,
      NotifyAtUtc = eu.NotifyAtUtc,
      UserInfo = userInfos.Where(u => u.UserId == eu.UserId).ToList(),
    }).ToList();
  }
}
