using System;
using UniversityHelper.EventService.Mappers.Db.Interfaces;
using UniversityHelper.EventService.Models.Db;

namespace UniversityHelper.EventService.Mappers.Db;

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
