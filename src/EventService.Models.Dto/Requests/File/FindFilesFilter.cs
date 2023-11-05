using System;
using HerzenHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.EventService.Models.Dto.Requests.File;

public record FindFilesFilter : BaseFindFilter
{
  [FromQuery(Name = "entityid")]
  public Guid EntityId { get; set; }
}
