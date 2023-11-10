using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.Image;
using UniversityHelper.EventService.Validation.Image.Interfaces;

namespace UniversityHelper.EventService.Validation.Image;

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
