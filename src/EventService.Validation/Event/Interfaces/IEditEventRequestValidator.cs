using System;
using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Validation.Event.Interfaces;

[AutoInject]
public interface IEditEventRequestValidator : IValidator<(Guid, JsonPatchDocument<EditEventRequest>)>
{
}
