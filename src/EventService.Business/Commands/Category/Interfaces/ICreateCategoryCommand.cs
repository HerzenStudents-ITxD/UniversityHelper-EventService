using System;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.Category.Interfaces;

[AutoInject]
public interface ICreateCategoryCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateCategoryRequest request);
}

