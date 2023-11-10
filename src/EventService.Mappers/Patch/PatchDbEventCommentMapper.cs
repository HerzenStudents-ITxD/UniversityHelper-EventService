using UniversityHelper.EventService.Mappers.Patch.Interfaces;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.EventComment;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace UniversityHelper.EventService.Mappers.Patch;

public class PatchDbEventCommentMapper : IPatchDbEventCommentMapper
{
  public JsonPatchDocument<DbEventComment> Map(JsonPatchDocument<EditEventCommentRequest> request)
  {
    if (request is null)
    {
      return null;
    }

    JsonPatchDocument<DbEventComment> dbEventCommentPatch = new();

    foreach (Operation<EditEventCommentRequest> item in request.Operations)
    {
      dbEventCommentPatch.Operations.Add(new Operation<DbEventComment>(
        item.op,
        item.path,
        item.from,
        string.IsNullOrEmpty(item.value?.ToString().Trim())
          ? null
          : item.value.ToString().Trim()));
    }

    return dbEventCommentPatch;
  }
}
