using UniversityHelper.EventService.Models.Dto.Enums;
using UniversityHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.EventService.Models.Dto.Requests.EventUser.Filter;

public record FindEventUsersFilter : BaseFindFilter
{
  [FromQuery(Name = "userFullNameIncludeSubstring")]
  public string UserFullNameIncludeSubstring { get; set; }

  [FromQuery(Name = "status")]
  public EventUserStatus? Status { get; set; }

  [FromQuery(Name = "isAscendingSort")]
  public bool? IsAscendingSort { get; set; }
}
