using System;
using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Validation.EventUser.Interfaces;

[AutoInject]
public interface IEditEventUserRequestValidator : IValidator<(Guid, JsonPatchDocument<EditEventUserRequest>)>
{
}
