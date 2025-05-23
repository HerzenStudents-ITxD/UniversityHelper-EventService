﻿using FluentValidation;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.EventService.Validation.Category.Interfaces;

namespace UniversityHelper.EventService.Validation.Category;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>, ICreateCategoryRequestValidator
{
  public CreateCategoryRequestValidator(
    ICategoryRepository categoryRepository)
  {
    RuleFor(request => request.Name)
      .Cascade(CascadeMode.Stop)
      .MinimumLength(1)
      .WithMessage("Name is too short")
      .MaximumLength(20)
      .WithMessage("Name is too long");
    
    RuleFor(request => request.Color)
      .IsInEnum()
      .WithMessage("Category doesn't contain such color");

    RuleFor(request => request)
      .MustAsync(async (request, _) => !await categoryRepository.DoesExistAsync(request.Name, request.Color))
      .WithMessage("Category already exists.");
  }
}

