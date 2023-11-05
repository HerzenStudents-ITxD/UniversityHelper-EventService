using System;
using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Business.Commands.Category.Interfaces;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.EventService.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<Guid?>> CreateCategoryController(
    [FromServices] ICreateCategoryCommand command,
    [FromBody] CreateCategoryRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpPatch("edit")]
  public Task<OperationResultResponse<bool>> EditAsync(
    [FromServices] IEditCategoryCommand command,
    [FromQuery] Guid categoryId,
    [FromBody] JsonPatchDocument<EditCategoryRequest> request)
  {
    return command.ExecuteAsync(categoryId, request);
  }

  [HttpGet("find")]
  public async Task<FindResultResponse<CategoryInfo>> FindCategoryFilter(
    [FromServices] IFindCategoriesCommand command,
    [FromQuery] FindCategoriesFilter filter,
    CancellationToken ct)
  {
    return await command.ExecuteAsync(filter: filter, cancellationToken: ct);
  }
}

