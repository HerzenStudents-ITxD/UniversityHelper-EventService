using HerzenHelper.EventService.Mappers.Models.Interface;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.Models.Broker.Models.Image;

namespace HerzenHelper.EventService.Mappers.Models;

public class ImageInfoMapper : IImageInfoMapper
{
  public ImageInfo Map(ImageData image)
  {
    return image is null
      ? default
      : new ImageInfo
      {
        Id = image.ImageId,
        ParentId = image.ParentId,
        Content = image.Content,
        Extension = image.Extension,
        Name = image.Name
      };
  }
}
