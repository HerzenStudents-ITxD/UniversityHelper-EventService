using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.EventService.Models.Dto.Requests.EventUser;

public record CreateEventUserRequest
{
  [Required]
  public Guid EventId { get; set; }
  [Required]
  public List<UserRequest> Users { get; set; }
}
