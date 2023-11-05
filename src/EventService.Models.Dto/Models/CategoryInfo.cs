using System;
using HerzenHelper.EventService.Models.Dto.Enums;

namespace HerzenHelper.EventService.Models.Dto.Models;

public class CategoryInfo
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public CategoryColor? Color { get; set; }
}

