using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.File;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Data.Interfaces;

[AutoInject]
public interface IFileRepository
{
  Task<List<Guid>> CreateAsync(List<DbFile> files);

  Task<bool> RemoveAsync(List<Guid> filesIds);

  Task<(List<DbFile>, int filesCount)> FindAsync(FindFilesFilter filter);

  Task<List<DbFile>> GetAsync(List<Guid> filesIds);

  Task<bool> DoExistAsync(Guid eventId, List<Guid> filesIds);
}
