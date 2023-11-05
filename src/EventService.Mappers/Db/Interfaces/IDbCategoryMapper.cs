using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbCategoryMapper
  {
    DbCategory Map(CreateCategoryRequest request);
  }
}
