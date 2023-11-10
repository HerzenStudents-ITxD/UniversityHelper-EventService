using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Mappers.Patch.Interfaces;

[AutoInject]
public interface IPatchDbEventMapper
{
  JsonPatchDocument<DbEvent> Map(JsonPatchDocument<EditEventRequest> request);
}
