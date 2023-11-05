using System;
using System.Collections.Generic;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Enums;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Mappers.Db.Interfaces;
[AutoInject]
public interface IDbEventUserMapper
{
  List<DbEventUser> Map(CreateEventUserRequest request, AccessType access, Guid senderId);
}
