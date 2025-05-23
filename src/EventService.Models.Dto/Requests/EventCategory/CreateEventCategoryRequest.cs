﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityHelper.EventService.Models.Dto.Requests.EventCategory;

public class CreateEventCategoryRequest
{
  public Guid EventId { get; set; }
  [Required]
  public List<Guid> CategoriesIds { get; set; }
}
