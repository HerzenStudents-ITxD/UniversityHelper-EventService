using System;
using HerzenHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.EventService.Models.Dto.Requests.UserBirthday;

public record FindUsersBirthdaysFilter : BaseFindFilter
{
  [FromQuery(Name = "StartTime")]
  public DateTime StartTime { get; set; }

  [FromQuery(Name = "EndTime")]
  public DateTime EndTime { get; set; }
}
