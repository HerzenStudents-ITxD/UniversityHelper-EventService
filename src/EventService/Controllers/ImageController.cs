using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.EventService.Business.Commands.Image.Interfaces;
using UniversityHelper.EventService.Models.Dto.Requests.Image;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.EventService.Controllers;

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
