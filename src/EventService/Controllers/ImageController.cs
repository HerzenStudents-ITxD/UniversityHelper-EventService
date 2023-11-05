using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.EventService.Business.Commands.Image.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests.Image;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.EventService.Controllers;

[Route("[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
  [HttpPost("create")]
  public async Task<OperationResultResponse<List<Guid>>> CreateAsync(
    [FromServices] ICreateImageCommand command,
    [FromBody] CreateImagesRequest request)
  {
    return await command.ExecuteAsync(request);
  }

  [HttpDelete("remove")]
  public async Task<OperationResultResponse<bool>> RemoveAsync(
    [FromServices] IRemoveImageCommand command,
    [FromBody] RemoveImageRequest request)
  {
    return await command.ExecuteAsync(request);
  }
}
