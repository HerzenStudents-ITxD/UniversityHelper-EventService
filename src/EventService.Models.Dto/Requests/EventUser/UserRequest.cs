using System;

namespace UniversityHelper.EventService.Models.Dto.Requests.EventUser;

public record UserRequest
{
  public Guid UserId { get; set; }
  public DateTime? NotifyAtUtc { get; set; }
}
