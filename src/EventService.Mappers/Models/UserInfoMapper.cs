using System.Collections.Generic;
using System.Linq;
using UniversityHelper.Models.Broker.Models.User;
using UniversityHelper.EventService.Mappers.Models.Interface;
using UniversityHelper.EventService.Models.Dto.Models;

namespace UniversityHelper.EventService.Mappers.Models;

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
