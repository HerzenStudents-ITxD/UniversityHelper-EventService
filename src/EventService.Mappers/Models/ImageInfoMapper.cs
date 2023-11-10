using UniversityHelper.EventService.Mappers.Models.Interface;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.Models.Broker.Models.Image;

namespace UniversityHelper.EventService.Mappers.Models;

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
