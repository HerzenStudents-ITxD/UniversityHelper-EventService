using System;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Business.Commands.Category.Interfaces;

[AutoInject]
public interface IEditCategoryCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid categoryId, JsonPatchDocument<EditCategoryRequest> patch);
}
