using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.EventComment;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Validation.EventComment.Interfaces;

[AutoInject]
public interface ICreateEventCommentRequestValidator : IValidator<CreateEventCommentRequest>
{
}
