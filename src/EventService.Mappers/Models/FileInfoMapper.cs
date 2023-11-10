using UniversityHelper.EventService.Mappers.Models.Interfaces;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.Models.Broker.Models.File;

namespace UniversityHelper.EventService.Mappers.Models;

public class FileInfoMapper : IFileInfoMapper
{
  public FileInfo Map(FileCharacteristicsData file)
  {
    if (file is null)
    {
      return null;
    }

    return new FileInfo
    {
      Id = file.Id,
      Name = file.Name,
      Extension = file.Extension,
      Size = file.Size,
      CreatedAtUtc = file.CreatedAtUtc
    };
  }
}
