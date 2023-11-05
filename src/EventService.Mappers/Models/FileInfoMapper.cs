using HerzenHelper.EventService.Mappers.Models.Interfaces;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.Models.Broker.Models.File;

namespace HerzenHelper.EventService.Mappers.Models;

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
