using System;
using UniversityHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.EventService.Models.Dto.Requests.UserBirthday;

public record FindUsersBirthdaysFilter : BaseFindFilter
{
  [FromQuery(Name = "StartTime")]
  public DateTime StartTime { get; set; }

  [FromQuery(Name = "EndTime")]
  public DateTime EndTime { get; set; }
}
