using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Mappers.Models.Interface;

[AutoInject]
public interface ICategoryInfoMapper
{
  CategoryInfo Map(DbCategory categories);
}
