using System.Collections.Generic;
using System;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.EventComment;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Mappers.Db.Interfaces;

[AutoInject]
public interface IDbEventCommentMapper
{
  public DbEventComment Map(CreateEventCommentRequest request, List<Guid> imagesIds);
}
