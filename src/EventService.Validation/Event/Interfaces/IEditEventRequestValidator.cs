using System;
using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.Event;
using HerzenHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Validation.Event.Interfaces;

[AutoInject]
public interface IEditEventRequestValidator : IValidator<(Guid, JsonPatchDocument<EditEventRequest>)>
{
}
