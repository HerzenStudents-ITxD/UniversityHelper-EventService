using System;
using HerzenHelper.EventService.Mappers.Db.Interfaces;
using HerzenHelper.EventService.Models.Db;

namespace HerzenHelper.EventService.Mappers.Db;

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
