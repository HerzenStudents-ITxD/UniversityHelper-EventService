using System;
using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Validation.Category.Interfaces;

[AutoInject]
public interface IEditCategoryRequestValidator : IValidator<(Guid, JsonPatchDocument<EditCategoryRequest>)>
{
}
