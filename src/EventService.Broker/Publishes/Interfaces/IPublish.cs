using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Broker.Publishes.Interfaces;

[AutoInject]
public interface IPublish
{
  Task RemoveImagesAsync(List<Guid> imagesIds);
  Task RemoveFilesAsync(List<Guid> filesIds);
}
