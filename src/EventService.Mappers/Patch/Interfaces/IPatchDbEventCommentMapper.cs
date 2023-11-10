using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.EventComment;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Mappers.Patch.Interfaces;

[AutoInject]
public interface IPatchDbEventCommentMapper
{
  JsonPatchDocument<DbEventComment> Map(JsonPatchDocument<EditEventCommentRequest> request);
}
