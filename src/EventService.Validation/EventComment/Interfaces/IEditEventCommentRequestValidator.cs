using System;
using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.EventComment;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Validation.EventComment.Interfaces;

[AutoInject]
public interface IEditEventCommentRequestValidator : IValidator<(Guid, JsonPatchDocument<EditEventCommentRequest>)>
{
}
