using System.Collections.Generic;
using System.Linq;
using HerzenHelper.Models.Broker.Models.User;
using HerzenHelper.EventService.Mappers.Models.Interface;
using HerzenHelper.EventService.Models.Dto.Models;

namespace HerzenHelper.EventService.Mappers.Models;

public class UserInfoMapper : IUserInfoMapper
{
  public List<UserInfo> Map(List<UserData> usersData)
  {
    return usersData?.Select(u => new UserInfo
    {
      UserId = u.Id,
      FirstName = u.FirstName,
      LastName = u.LastName,
      MiddleName = u.MiddleName,
      ImageId = u.ImageId
    }).ToList();
  }
}
