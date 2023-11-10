using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Validation.Category.Interfaces;

[AutoInject]
public interface ICreateCategoryRequestValidator : IValidator<CreateCategoryRequest>
{
}

