using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Data.Interfaces;

[AutoInject]
public interface IEventCategoryRepository
{
  Task<bool> CreateAsync(List<DbEventCategory> dbEventCategory);

  bool DoesExistAsync(Guid eventId, List<Guid> categoriesIds);

  Task<int> CountCategoriesAsync(Guid eventId);

  Task<bool> RemoveAsync(Guid eventId, List<Guid> categoriesIds);
}
