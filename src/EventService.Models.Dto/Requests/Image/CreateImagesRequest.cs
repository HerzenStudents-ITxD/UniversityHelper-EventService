using System;
using System.Collections.Generic;

namespace HerzenHelper.EventService.Models.Dto.Requests.Image;

public record CreateImagesRequest
{
  public Guid EntityId { get; set; }
  public List<ImageContent> Images { get; set; }
}
