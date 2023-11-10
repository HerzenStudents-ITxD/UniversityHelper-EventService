using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Db.Interfaces
{
  [AutoInject]
  public interface IDbCategoryMapper
  {
    DbCategory Map(CreateCategoryRequest request);
  }
}
