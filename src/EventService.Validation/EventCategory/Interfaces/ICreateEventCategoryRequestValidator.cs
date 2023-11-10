using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.EventCategory;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Validation.EventCategory.Interfaces;

[AutoInject]
public interface ICreateEventCategoryRequestValidator : IValidator<CreateEventCategoryRequest>
{
}

