using System;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.EventCategory;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.EventCategory.Interfaces;

[AutoInject]
public interface ICreateEventCategoryCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(CreateEventCategoryRequest request);
}
