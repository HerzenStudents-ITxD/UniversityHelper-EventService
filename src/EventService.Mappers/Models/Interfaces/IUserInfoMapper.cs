using System.Collections.Generic;
using UniversityHelper.Models.Broker.Models.User;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Models.Interfaces;

[AutoInject]
public interface IUserInfoMapper
{
  List<UserInfo> Map(List<UserData> usersData);
}
