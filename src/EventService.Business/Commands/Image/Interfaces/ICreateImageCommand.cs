using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.Image;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.Image.Interfaces;

[AutoInject]
public interface ICreateImageCommand
{
  Task<OperationResultResponse<List<Guid>>> ExecuteAsync(CreateImagesRequest request);
}
