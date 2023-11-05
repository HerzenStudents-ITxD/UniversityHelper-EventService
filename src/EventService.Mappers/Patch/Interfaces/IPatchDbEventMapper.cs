using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.Event;
using HerzenHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Mappers.Patch.Interfaces;

[AutoInject]
public interface IPatchDbEventMapper
{
  JsonPatchDocument<DbEvent> Map(JsonPatchDocument<EditEventRequest> request);
}
