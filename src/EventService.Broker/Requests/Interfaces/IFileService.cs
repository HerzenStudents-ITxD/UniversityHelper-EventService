using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Models.Broker.Models.File;

namespace HerzenHelper.EventService.Broker.Requests.Interfaces;

[AutoInject]
public interface IFileService
{
  Task<List<FileCharacteristicsData>> GetFilesCharacteristicsAsync(List<Guid> filesIds, List<string> errors = null);
}
