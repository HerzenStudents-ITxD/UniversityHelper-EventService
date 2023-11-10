using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Models.Interface;

[AutoInject]
public interface ICategoryInfoMapper
{
  CategoryInfo Map(DbCategory categories);
}
