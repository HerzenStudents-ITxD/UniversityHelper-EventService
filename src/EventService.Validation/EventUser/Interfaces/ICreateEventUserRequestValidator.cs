using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Validation.EventUser.Interfaces;

[AutoInject]
public interface ICreateEventUserRequestValidator : IValidator<CreateEventUserRequest>
{
}
