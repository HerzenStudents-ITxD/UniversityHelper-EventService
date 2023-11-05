using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HerzenHelper.EventService.Business.Commands.EventCategory.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests.EventCategory;

namespace HerzenHelper.EventService.Controllers;

[Route("[controller]")]
[ApiController]
public class EventCategoryController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<bool>> CreateAsync(
    [FromServices] ICreateEventCategoryCommand command,
    [FromBody] CreateEventCategoryRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpDelete("remove")]
    public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemoveEventCategoryCommand command,
    [FromBody] RemoveEventCategoryRequest request)
  {
    return await command.ExecuteAsync(request);
  }
}
