using System;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Business.Commands.Category.Interfaces;

[AutoInject]
public interface IEditCategoryCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid categoryId, JsonPatchDocument<EditCategoryRequest> patch);
}
