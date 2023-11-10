using System;
using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Validation.Category.Interfaces;

[AutoInject]
public interface IEditCategoryRequestValidator : IValidator<(Guid, JsonPatchDocument<EditCategoryRequest>)>
{
}
