using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.EventComment;
using HerzenHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Mappers.Patch.Interfaces;

[AutoInject]
public interface IPatchDbEventCommentMapper
{
  JsonPatchDocument<DbEventComment> Map(JsonPatchDocument<EditEventCommentRequest> request);
}
