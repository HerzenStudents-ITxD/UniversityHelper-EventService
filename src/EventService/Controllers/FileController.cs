using System.Threading.Tasks;
using HerzenHelper.EventService.Business.Commands.File.Interfaces;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.File;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.EventService.Controllers;

[Route("[controller]")]
[ApiController]
public class FileController : ControllerBase
{
  [HttpGet("find")]
  public async Task<FindResultResponse<FileInfo>> FindAsync(
    [FromServices] IFindFilesCommand command,
    [FromQuery] FindFilesFilter findFilter)
  {
    return await command.ExecuteAsync(findFilter);
  }

  [HttpDelete("remove")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemoveFilesCommand command,
    [FromBody] RemoveFilesRequest request)
  {
    return await command.ExecuteAsync(request);
  }
}
