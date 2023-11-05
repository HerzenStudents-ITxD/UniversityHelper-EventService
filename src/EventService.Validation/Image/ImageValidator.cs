using FluentValidation;
using HerzenHelper.Core.Validators.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests;
using HerzenHelper.EventService.Validation.Image.Interfaces;

namespace HerzenHelper.EventService.Validation.Image;

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
