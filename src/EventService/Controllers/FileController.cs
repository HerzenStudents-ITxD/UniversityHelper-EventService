using System.Threading.Tasks;
using UniversityHelper.EventService.Business.Commands.File.Interfaces;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.File;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.EventService.Controllers;

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
