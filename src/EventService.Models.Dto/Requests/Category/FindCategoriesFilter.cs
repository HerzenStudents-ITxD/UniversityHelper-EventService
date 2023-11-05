using HerzenHelper.EventService.Models.Dto.Enums;
using HerzenHelper.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.EventService.Models.Dto.Requests.Category;

public record FindCategoriesFilter : BaseFindFilter
{
  [FromQuery(Name = "nameIncludeSubstring")]
  public string NameIncludeSubstring { get; set; }

  [FromQuery(Name = "color")]
  public CategoryColor? Color { get; set; }
  
  [FromQuery(Name = "isAscendingSort")]
  public bool? IsAscendingSort { get; set; }
}

