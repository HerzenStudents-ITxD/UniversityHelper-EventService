using System;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.EventCategory;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.EventCategory.Interfaces;

[AutoInject]
public interface ICreateEventCategoryCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(CreateEventCategoryRequest request);
}
