﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HerzenHelper.EventService.Models.Dto.Requests.EventCategory;

public class RemoveEventCategoryRequest
{
  public Guid EventId { get; set; }
  [Required]
  public List<Guid> CategoriesIds { get; set; }
}
