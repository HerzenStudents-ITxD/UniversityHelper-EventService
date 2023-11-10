using System;
using System.Collections.Generic;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbEventMapper
{
  DbEvent Map(CreateEventRequest request, Guid senderId, List<Guid> imagesIds);
}
