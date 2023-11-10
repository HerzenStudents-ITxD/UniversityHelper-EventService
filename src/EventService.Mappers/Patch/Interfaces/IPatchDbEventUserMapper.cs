using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Mappers.Patch.Interfaces;

[AutoInject]
public interface IPatchDbEventUserMapper
{
  JsonPatchDocument<DbEventUser> Map(JsonPatchDocument<EditEventUserRequest> request);
}
