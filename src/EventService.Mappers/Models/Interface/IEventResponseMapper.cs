using System.Collections.Generic;
using UniversityHelper.Models.Broker.Models.User;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Responses.Event;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Models.Broker.Models.File;
using UniversityHelper.Models.Broker.Models.Image;

namespace UniversityHelper.EventService.Mappers.Models.Interface;

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
