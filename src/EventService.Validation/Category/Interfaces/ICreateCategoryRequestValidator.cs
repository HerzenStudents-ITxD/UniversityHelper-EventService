using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Validation.Category.Interfaces;

[AutoInject]
public interface ICreateCategoryRequestValidator : IValidator<CreateCategoryRequest>
{
}

