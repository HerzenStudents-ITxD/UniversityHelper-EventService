using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.Image;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.Image.Interfaces;

[AutoInject]
public interface ICreateImageCommand
{
  Task<OperationResultResponse<List<Guid>>> ExecuteAsync(CreateImagesRequest request);
}
