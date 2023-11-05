using System.Collections.Generic;
using System;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.EventComment;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbEventCommentMapper
{
  public DbEventComment Map(CreateEventCommentRequest request, List<Guid> imagesIds);
}
