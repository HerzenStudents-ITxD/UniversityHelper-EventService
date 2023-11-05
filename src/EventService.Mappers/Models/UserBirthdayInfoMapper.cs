using System;
using HerzenHelper.EventService.Mappers.Models.Interface;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Models;

namespace HerzenHelper.EventService.Mappers.Models;

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
