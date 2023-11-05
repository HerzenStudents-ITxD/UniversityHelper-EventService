using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Data.Interfaces;

[AutoInject]
public interface IImageRepository
{
  Task<List<Guid>> CreateAsync(List<DbImage> images);

  Task<bool> RemoveAsync(List<Guid> imagesIds);
}
