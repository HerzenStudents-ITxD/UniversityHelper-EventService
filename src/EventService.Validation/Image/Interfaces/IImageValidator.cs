using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Validation.Image.Interfaces;

[AutoInject]
public interface IImageValidator : IValidator<ImageContent>
{
}
