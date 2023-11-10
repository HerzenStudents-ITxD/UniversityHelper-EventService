using System;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbImageMapper
{
  DbImage Map(Guid imageId, Guid entityId);
}
