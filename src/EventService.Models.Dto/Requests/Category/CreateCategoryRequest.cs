using System.ComponentModel.DataAnnotations;
using HerzenHelper.EventService.Models.Dto.Enums;

namespace HerzenHelper.EventService.Models.Dto.Requests.Category;

public class CreateCategoryRequest
{
  [Required]
  public string Name { get; set; }
  public CategoryColor Color { get; set; }
}

