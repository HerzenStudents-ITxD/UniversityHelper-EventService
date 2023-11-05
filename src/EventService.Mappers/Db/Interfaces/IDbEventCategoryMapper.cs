using System.Collections.Generic;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.EventCategory;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbEventCategoryMapper
{
  List<DbEventCategory> Map(CreateEventCategoryRequest request);
}
