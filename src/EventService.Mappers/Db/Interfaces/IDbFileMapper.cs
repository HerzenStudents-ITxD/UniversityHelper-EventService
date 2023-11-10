using System;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbFileMapper
{
  DbFile Map(Guid fileId, Guid eventId);
}
