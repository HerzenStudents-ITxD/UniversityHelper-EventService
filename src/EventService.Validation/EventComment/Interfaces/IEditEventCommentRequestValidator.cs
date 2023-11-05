using System;
using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.EventComment;
using HerzenHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Validation.EventComment.Interfaces;

[AutoInject]
public interface IEditEventCommentRequestValidator : IValidator<(Guid, JsonPatchDocument<EditEventCommentRequest>)>
{
}
