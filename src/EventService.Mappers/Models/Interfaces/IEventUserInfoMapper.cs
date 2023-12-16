using System.Collections.Generic;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Models.Interfaces;

[AutoInject]
public interface IEventUserInfoMapper
{
  List<EventUserInfo> Map(List<UserInfo> userInfos, List<DbEventUser> eventUsers);
}
