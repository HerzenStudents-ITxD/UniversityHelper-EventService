﻿using System;
using System.Collections.Generic;

namespace HerzenHelper.EventService.Models.Dto.Requests.Image;

public record RemoveImageRequest
{
  public Guid EntityId { get; set; }
  public List<Guid> ImagesIds { get; set; }
}
