using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Validation.Image.Interfaces;

[AutoInject]
public interface IImageValidator : IValidator<ImageContent>
{
}
