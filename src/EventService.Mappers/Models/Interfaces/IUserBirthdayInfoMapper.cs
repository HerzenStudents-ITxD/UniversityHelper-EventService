using System;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Models.Interfaces;

[AutoInject]
public interface IUserBirthdayInfoMapper
{
  UserBirthdayInfo Map(DbUserBirthday userBirthday, DateTime dateOfBirth);
}
