using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser;
using HerzenHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Mappers.Patch.Interfaces;

[AutoInject]
public interface IPatchDbEventUserMapper
{
  JsonPatchDocument<DbEventUser> Map(JsonPatchDocument<EditEventUserRequest> request);
}
