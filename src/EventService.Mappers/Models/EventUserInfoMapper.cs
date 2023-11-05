using System.Collections.Generic;
using System.Linq;
using HerzenHelper.EventService.Mappers.Models.Interface;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Models;

namespace HerzenHelper.EventService.Mappers.Models;

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
