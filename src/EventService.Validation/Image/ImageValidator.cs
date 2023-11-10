using FluentValidation;
using UniversityHelper.Core.Validators.Interfaces;
using UniversityHelper.EventService.Models.Dto.Requests;
using UniversityHelper.EventService.Validation.Image.Interfaces;

namespace UniversityHelper.EventService.Validation.Image;

public class ImageValidator : AbstractValidator<ImageContent>, IImageValidator
{
  public ImageValidator(
    IImageContentValidator contentValidator,
    IImageExtensionValidator extensionValidator)
  {
    RuleFor(i => i.Content)
      .SetValidator(contentValidator);

    RuleFor(i => i.Extension)
      .SetValidator(extensionValidator);
  }
}
