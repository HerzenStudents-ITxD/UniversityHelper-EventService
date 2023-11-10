using System;
using System.Collections.Generic;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Enums;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Db.Interfaces;
[AutoInject]
public interface IDbEventUserMapper
{
  List<DbEventUser> Map(CreateEventUserRequest request, AccessType access, Guid senderId);
}
