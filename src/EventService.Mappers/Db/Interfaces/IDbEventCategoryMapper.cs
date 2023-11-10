using System.Collections.Generic;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.EventCategory;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbEventCategoryMapper
{
  List<DbEventCategory> Map(CreateEventCategoryRequest request);
}
