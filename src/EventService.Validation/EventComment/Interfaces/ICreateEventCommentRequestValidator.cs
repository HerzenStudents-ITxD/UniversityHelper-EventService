using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.EventComment;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Validation.EventComment.Interfaces;

[AutoInject]
public interface ICreateEventCommentRequestValidator : IValidator<CreateEventCommentRequest>
{
}
