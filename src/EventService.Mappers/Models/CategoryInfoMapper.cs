using UniversityHelper.EventService.Mappers.Models.Interface;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;

namespace UniversityHelper.EventService.Mappers.Models;

public class CategoryInfoMapper : ICategoryInfoMapper
{
  public CategoryInfo Map(DbCategory dbCategory)
  {
    return dbCategory is null
      ? null
      : new CategoryInfo 
      {
        Id = dbCategory.Id, 
        Name = dbCategory.Name, 
        Color = dbCategory.Color 
      };
  }
}
