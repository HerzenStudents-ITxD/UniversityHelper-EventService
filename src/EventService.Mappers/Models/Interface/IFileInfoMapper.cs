using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Models.Broker.Models.File;

namespace UniversityHelper.EventService.Mappers.Models.Interfaces;

[AutoInject]
public interface IFileInfoMapper
{
  FileInfo Map(FileCharacteristicsData file);
}
