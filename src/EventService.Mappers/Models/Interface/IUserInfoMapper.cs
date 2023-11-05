using System.Collections.Generic;
using HerzenHelper.Models.Broker.Models.User;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Mappers.Models.Interface;

[AutoInject]
public interface IUserInfoMapper
{
  List<UserInfo> Map(List<UserData> usersData);
}
