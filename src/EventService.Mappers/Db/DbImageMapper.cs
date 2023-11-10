using System;
using UniversityHelper.EventService.Mappers.Db.Interfaces;
using UniversityHelper.EventService.Models.Db;

namespace UniversityHelper.EventService.Mappers.Db;

public class DbImageMapper : IDbImageMapper
{
  public DbImage Map(Guid imageId, Guid entityId)
  {
    return new DbImage
    {
      Id = Guid.NewGuid(),
      ImageId = imageId,
      EntityId = entityId
    };
  }
}
