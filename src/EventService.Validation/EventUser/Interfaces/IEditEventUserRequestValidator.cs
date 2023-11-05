using System;
using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser;
using HerzenHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Validation.EventUser.Interfaces;

[AutoInject]
public interface IEditEventUserRequestValidator : IValidator<(Guid, JsonPatchDocument<EditEventUserRequest>)>
{
}
