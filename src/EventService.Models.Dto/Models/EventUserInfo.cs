using System;
using System.Collections.Generic;
using HerzenHelper.EventService.Models.Dto.Enums;

namespace HerzenHelper.EventService.Models.Dto.Models;

public record EventUserInfo
{
  public Guid Id { get; set; }
  public EventUserStatus Status { get; set; }
  public DateTime? NotifyAtUtc { get; set; }
  public List<UserInfo> UserInfo { get; set; }
}
