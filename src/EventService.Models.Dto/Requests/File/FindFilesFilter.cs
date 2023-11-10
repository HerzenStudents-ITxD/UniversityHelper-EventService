using System;
using UniversityHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.EventService.Models.Dto.Requests.File;

public record FindFilesFilter : BaseFindFilter
{
  [FromQuery(Name = "entityid")]
  public Guid EntityId { get; set; }
}
