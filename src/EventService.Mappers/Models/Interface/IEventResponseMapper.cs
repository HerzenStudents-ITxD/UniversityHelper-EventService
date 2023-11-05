using System.Collections.Generic;
using HerzenHelper.Models.Broker.Models.User;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Responses.Event;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Models.Broker.Models.File;
using HerzenHelper.Models.Broker.Models.Image;

namespace HerzenHelper.EventService.Mappers.Models.Interface;

[AutoInject]
public interface IEventResponseMapper
{
  EventResponse Map(
    DbEvent dbEvent,
    List<UserData> usersData,
    List<ImageInfo> images,
    List<FileCharacteristicsData> files,
    List<CommentInfo> comments);
}
