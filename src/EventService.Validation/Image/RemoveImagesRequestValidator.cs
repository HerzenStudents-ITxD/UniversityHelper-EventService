using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.Image;
using HerzenHelper.EventService.Validation.Image.Interfaces;

namespace HerzenHelper.EventService.Validation.Image;

public class RemoveImagesRequestValidator : AbstractValidator<RemoveImageRequest>, IRemoveImagesRequestValidator
{
  public RemoveImagesRequestValidator()
  {
    RuleFor(request => request.ImagesIds)
      .NotEmpty()
      .WithMessage("List of images ids must not be null or empty.")
      .ForEach(imageId => 
        imageId.NotEmpty()
          .WithMessage("Image Id must not be empty."));
  }
}
