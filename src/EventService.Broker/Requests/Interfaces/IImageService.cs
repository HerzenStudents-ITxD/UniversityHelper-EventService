using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.Models.Broker.Models.Image;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Broker.Requests.Interfaces;

[AutoInject]
public interface IImageService
{
  Task<List<Guid>> CreateImagesAsync(List<ImageContent> images, ResizeParameters resizeParameters, List<string> errors = null);
  Task<List<ImageInfo>> GetImagesAsync(List<Guid> imagesIds, List<string> errors = null);
}
