using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Mappers.Patch.Interfaces;

[AutoInject]
public interface IPatchDbCategoryMapper
{
  JsonPatchDocument<DbCategory> Map(JsonPatchDocument<EditCategoryRequest> request);
}
