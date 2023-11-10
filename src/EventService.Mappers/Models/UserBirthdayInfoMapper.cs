using System;
using UniversityHelper.EventService.Mappers.Models.Interface;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;

namespace UniversityHelper.EventService.Mappers.Models;

public class UserBirthdayInfoMapper : IUserBirthdayInfoMapper
{
  public UserBirthdayInfo Map(DbUserBirthday userBirthday, DateTime dateOfBirth)
  {
    return userBirthday is null
      ? null
      : new UserBirthdayInfo
      {
        UserId = userBirthday.UserId,
        DateOfBirth = dateOfBirth,
      };
  }
}
