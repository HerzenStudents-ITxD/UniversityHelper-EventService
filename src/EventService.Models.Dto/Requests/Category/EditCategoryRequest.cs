using HerzenHelper.EventService.Models.Dto.Enums;

namespace HerzenHelper.EventService.Models.Dto.Requests.Category;

public class EditCategoryRequest
{
  public string Name { get; set; }
  public CategoryColor Color { get; set; }
  public bool IsActive { get; set; }
}
