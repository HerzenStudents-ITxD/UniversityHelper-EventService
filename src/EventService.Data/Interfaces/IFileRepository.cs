using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.File;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Data.Interfaces;

[AutoInject]
public interface IFileRepository
{
  Task<List<Guid>> CreateAsync(List<DbFile> files);

  Task<bool> RemoveAsync(List<Guid> filesIds);

  Task<(List<DbFile>, int filesCount)> FindAsync(FindFilesFilter filter);

  Task<List<DbFile>> GetAsync(List<Guid> filesIds);

  Task<bool> DoExistAsync(Guid eventId, List<Guid> filesIds);
}
