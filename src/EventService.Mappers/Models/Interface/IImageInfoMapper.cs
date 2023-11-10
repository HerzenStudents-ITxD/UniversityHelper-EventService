using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Models.Broker.Models.Image;

namespace UniversityHelper.EventService.Mappers.Models.Interface;

[AutoInject]
public interface IImageInfoMapper
{
  ImageInfo Map(ImageData image);
}
