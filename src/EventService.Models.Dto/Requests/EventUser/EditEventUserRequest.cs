using System;
using HerzenHelper.EventService.Models.Dto.Enums;

namespace HerzenHelper.EventService.Models.Dto.Requests.EventUser;

public class EditEventUserRequest
{
  public EventUserStatus Status { get; set; }
  public DateTime? NotifyAtUtc { get; set; }
}
