using System;
using UniversityHelper.EventService.Models.Dto.Enums;
using UniversityHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.EventService.Models.Dto.Requests.Event;

public record FindEventsFilter : BaseFindFilter
{
  [FromQuery(Name = "userId")]
  public Guid? UserId { get; set; }

  [FromQuery(Name = "nameIncludeSubstring")]
  public string NameIncludeSubstring { get; set; }

  [FromQuery(Name = "categoryNameIncludeSubstring")]
  public string CategoryNameIncludeSubstring { get; set; }

  [FromQuery(Name = "includeDeactivated")]
  public bool IncludeDeactivated { get; set; } = false;

  [FromQuery(Name = "startTime")]
  public DateTime? StartTime { get; set; }

  [FromQuery(Name = "endTime")]
  public DateTime? EndTime { get; set; }

  [FromQuery(Name = "access")]
  public AccessType? Access { get; set; }

  [FromQuery(Name = "color")]
  public CategoryColor? Color { get; set; }
}

