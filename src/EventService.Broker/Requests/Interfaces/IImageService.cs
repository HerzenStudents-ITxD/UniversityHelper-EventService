using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.Models.Broker.Models.Image;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Broker.Requests.Interfaces;

[AutoInject]
public interface IImageService
{
  Task<List<Guid>> CreateImagesAsync(List<ImageContent> images, ResizeParameters resizeParameters, List<string> errors = null);
  Task<List<ImageInfo>> GetImagesAsync(List<Guid> imagesIds, List<string> errors = null);
}
