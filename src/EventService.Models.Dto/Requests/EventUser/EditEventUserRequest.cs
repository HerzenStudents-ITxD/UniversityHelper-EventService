using System;
using UniversityHelper.EventService.Models.Dto.Enums;

namespace UniversityHelper.EventService.Models.Dto.Requests.EventUser;

public class EditEventUserRequest
{
  public EventUserStatus Status { get; set; }
  public DateTime? NotifyAtUtc { get; set; }
}
