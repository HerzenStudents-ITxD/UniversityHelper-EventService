using FluentValidation;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests.EventCategory;
using HerzenHelper.EventService.Validation.EventCategory.Interfaces;

namespace HerzenHelper.EventService.Validation.EventCategory;

public class RemoveEventCategoryRequestValidator : AbstractValidator<RemoveEventCategoryRequest>, IRemoveEventCategoryRequestValidator
{
  public RemoveEventCategoryRequestValidator(
    IEventRepository eventRepository,
    ICategoryRepository categoryRepository,
    IEventCategoryRepository eventCategoryRepository)
  {
    RuleFor(request => request.EventId)
      .MustAsync((x, _) => eventRepository.DoesExistAsync(x, true))
      .WithMessage("This event doesn't exist.");

    RuleFor(request => request.CategoriesIds)
      .NotEmpty()
      .WithMessage("There are no categories to delete.")
      .MustAsync((categories, _) => categoryRepository.DoExistAllAsync(categories))
      .WithMessage("Some categories doesn't exist.");

    RuleFor(request => request)
      .Must(x => eventCategoryRepository.DoesExistAsync(x.EventId, x.CategoriesIds))
      .WithMessage("This event doesn't belong to all categories in the list.");
  }
}
