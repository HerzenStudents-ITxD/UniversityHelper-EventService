﻿using System;
using UniversityHelper.EventService.Models.Dto.Enums;

namespace UniversityHelper.EventService.Models.Dto.Requests.Event;

public record EditEventRequest
{
  public string Name { get; set; }
  public string Address { get; set; }
  public string Description { get; set; }
  public DateTime Date { get; set; }
  public DateTime? EndDate { get; set; }
  public FormatType Format { get; set; }
  public AccessType Access { get; set; }
  public bool IsActive { get; set; }
}
