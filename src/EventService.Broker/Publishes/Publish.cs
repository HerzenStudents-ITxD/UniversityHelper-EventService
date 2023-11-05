using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.Models.Broker.Enums;
using HerzenHelper.EventService.Broker.Publishes.Interfaces;
using HerzenHelper.Models.Broker.Enums;
using HerzenHelper.Models.Broker.Publishing.Subscriber.File;
using HerzenHelper.Models.Broker.Publishing.Subscriber.Image;
using MassTransit;

namespace HerzenHelper.EventService.Broker.Publishes;

public class Publish : IPublish
{
  private readonly IBus _bus;

  public Publish(IBus bus)
  {
    _bus = bus;
  }

  public Task RemoveImagesAsync(List<Guid> imagesIds)
  {
    return _bus.Publish<IRemoveImagesPublish>(IRemoveImagesPublish.CreateObj(
      imagesIds: imagesIds,
      imageSource: ImageSource.Event));
  }

  public Task RemoveFilesAsync(List<Guid> filesIds)
  {
    return _bus.Publish<IRemoveFilesPublish>(IRemoveFilesPublish.CreateObj(FileSource.Event, filesIds));
  }
}
