using UniversityHelper.EventService.Mappers.Patch.Interfaces;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace UniversityHelper.EventService.Mappers.Patch;

public class PatchDbEventUserMapper : IPatchDbEventUserMapper
{
  public JsonPatchDocument<DbEventUser> Map(JsonPatchDocument<EditEventUserRequest> request)
  {
    if (request is null)
    {
      return null;
    }

    JsonPatchDocument<DbEventUser> dbEventUserPatch = new();

    foreach (Operation<EditEventUserRequest> item in request.Operations)
    {
      dbEventUserPatch.Operations.Add(new Operation<DbEventUser>(
        item.op,
        item.path,
        item.from,
        string.IsNullOrEmpty(item.value?.ToString().Trim())
          ? null
          : item.value.ToString().Trim()));
    }

    return dbEventUserPatch;
  }
}
