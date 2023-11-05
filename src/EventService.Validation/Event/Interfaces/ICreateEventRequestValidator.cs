using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.Event;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Validation.Event.Interfaces;

[AutoInject]
public interface ICreateEventRequestValidator : IValidator<CreateEventRequest>
{
}
