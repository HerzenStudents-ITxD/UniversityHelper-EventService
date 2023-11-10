using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Data.Interfaces;

[AutoInject]
public interface IEventCommentRepository
{
  Task<Guid?> CreateAsync(DbEventComment dbEventComment);
  Task<bool> EditContentAsync(Guid commentId, JsonPatchDocument<DbEventComment> request);
  Task<(bool, List<Guid> filesIds, List<Guid> imagesIds)> EditIsActiveAsync(Guid commentId, JsonPatchDocument<DbEventComment> request);
  Task<DbEventComment> GetAsync(Guid commentId);
  Task<bool> DoesExistAsync(Guid commentId);
  Task<List<Guid>> GetExisting(List<Guid> commentsIds);
  Task<bool> HasChildCommentsAsync(Guid commentId);
}
