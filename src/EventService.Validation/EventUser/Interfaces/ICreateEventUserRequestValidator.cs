using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Validation.EventUser.Interfaces;

[AutoInject]
public interface ICreateEventUserRequestValidator : IValidator<CreateEventUserRequest>
{
}
