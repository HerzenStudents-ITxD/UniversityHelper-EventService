using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Models.Broker.Models.Image;

namespace HerzenHelper.EventService.Mappers.Models.Interface;

[AutoInject]
public interface IImageInfoMapper
{
  ImageInfo Map(ImageData image);
}
