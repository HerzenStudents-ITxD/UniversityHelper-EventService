using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Data.Interfaces;

[AutoInject]
public interface IImageRepository
{
  Task<List<Guid>> CreateAsync(List<DbImage> images);

  Task<bool> RemoveAsync(List<Guid> imagesIds);
}
