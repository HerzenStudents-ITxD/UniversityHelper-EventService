using System;
using System.Collections.Generic;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.Event;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbEventMapper
{
  DbEvent Map(CreateEventRequest request, Guid senderId, List<Guid> imagesIds);
}
