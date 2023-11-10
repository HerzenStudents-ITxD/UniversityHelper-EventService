using System;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.Category.Interfaces;

[AutoInject]
public interface ICreateCategoryCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateCategoryRequest request);
}

