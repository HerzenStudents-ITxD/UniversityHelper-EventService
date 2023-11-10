using System;

namespace UniversityHelper.EventService.Models.Dto.Models;

public record UserBirthdayInfo
{
  public Guid UserId { get; set; }
  public DateTime DateOfBirth { get; set; }
}
