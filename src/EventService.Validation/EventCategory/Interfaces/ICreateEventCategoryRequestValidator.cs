using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.EventCategory;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Validation.EventCategory.Interfaces;

[AutoInject]
public interface ICreateEventCategoryRequestValidator : IValidator<CreateEventCategoryRequest>
{
}

