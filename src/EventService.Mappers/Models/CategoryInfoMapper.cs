using HerzenHelper.EventService.Mappers.Models.Interface;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Models;

namespace HerzenHelper.EventService.Mappers.Models;

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
