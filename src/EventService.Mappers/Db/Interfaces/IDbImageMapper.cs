using System;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbImageMapper
{
  DbImage Map(Guid imageId, Guid entityId);
}
