﻿using FluentValidation;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Models.Dto.Requests.EventCategory;
using UniversityHelper.EventService.Validation.EventCategory.Interfaces;

namespace UniversityHelper.EventService.Validation.EventCategory;

public class CreateEventCategoryRequestValidator : AbstractValidator<CreateEventCategoryRequest>, ICreateEventCategoryRequestValidator
{
  public CreateEventCategoryRequestValidator(
    IEventRepository eventRepository,
    ICategoryRepository categoryRepository,
    IEventCategoryRepository eventCategoryRepository)
  {
    RuleFor(x => x.EventId)
      .MustAsync((eventId, _) => eventRepository.DoesExistAsync(eventId, true))
      .WithMessage("This event doesn't exist.");

    RuleFor(x => x.CategoriesIds)
      .MustAsync((categories, _) => categoryRepository.DoExistAllAsync(categories))
      .WithMessage("Some of categories in the list doesn't exist.");

    RuleFor(x => x)
      .Must(ec => !eventCategoryRepository.DoesExistAsync(ec.EventId, ec.CategoriesIds))
      .WithMessage("This event already belongs to this category.")
      .MustAsync(async (ec, _) => await eventCategoryRepository.CountCategoriesAsync(ec.EventId) + ec.CategoriesIds.Count < 2)
      .WithMessage("This event already has 5 categories.");
  }
}
