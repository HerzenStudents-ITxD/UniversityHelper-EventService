using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Mappers.Patch.Interfaces;

[AutoInject]
public interface IPatchDbCategoryMapper
{
  JsonPatchDocument<DbCategory> Map(JsonPatchDocument<EditCategoryRequest> request);
}
