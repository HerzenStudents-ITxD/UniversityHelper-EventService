﻿using System;
using System.Collections.Generic;
using System.Linq;
using HerzenHelper.EventService.Mappers.Db.Interfaces;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Enums;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser;

namespace HerzenHelper.EventService.Mappers.Db;

public class DbEventUserMapper : IDbEventUserMapper
{
  public List<DbEventUser> Map(
    CreateEventUserRequest request,
    AccessType access,
    Guid senderId)
  {
    return request is null
      ? null
      : request.Users.Select(u => new DbEventUser
      {
        Id = Guid.NewGuid(),
        EventId = request.EventId,
        UserId = u.UserId,
        Status = (access == AccessType.Opened && u.UserId == senderId)
          ? EventUserStatus.Participant
          : EventUserStatus.Invited,
        NotifyAtUtc = u.NotifyAtUtc,
        CreatedBy = senderId,
        CreatedAtUtc = DateTime.UtcNow
      }).ToList();
  }
}
