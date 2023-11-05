using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Models.Broker.Models.File;

namespace HerzenHelper.EventService.Mappers.Models.Interfaces;

[AutoInject]
public interface IFileInfoMapper
{
  FileInfo Map(FileCharacteristicsData file);
}
