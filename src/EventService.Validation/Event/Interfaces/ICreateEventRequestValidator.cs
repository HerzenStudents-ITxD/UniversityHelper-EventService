using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Validation.Event.Interfaces;

[AutoInject]
public interface ICreateEventRequestValidator : IValidator<CreateEventRequest>
{
}
