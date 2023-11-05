using System;
using HerzenHelper.EventService.Mappers.Db.Interfaces;
using HerzenHelper.EventService.Models.Db;

namespace HerzenHelper.EventService.Mappers.Db;

public class DbFileMapper : IDbFileMapper
{
  public DbFile Map(Guid fileId, Guid entityId)
  {
    return new DbFile
    {
      Id = Guid.NewGuid(),
      FileId = fileId,
      EntityId = entityId
    };
  }
}
