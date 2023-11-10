using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.Image;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Validation.Image.Interfaces;

[AutoInject]
public interface ICreateImagesRequestValidator : IValidator<CreateImagesRequest>
{
}
