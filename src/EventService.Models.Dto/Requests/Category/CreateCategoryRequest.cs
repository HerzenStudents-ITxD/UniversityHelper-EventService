using System.ComponentModel.DataAnnotations;
using UniversityHelper.EventService.Models.Dto.Enums;

namespace UniversityHelper.EventService.Models.Dto.Requests.Category;

public class CreateCategoryRequest
{
  [Required]
  public string Name { get; set; }
  public CategoryColor Color { get; set; }
}

