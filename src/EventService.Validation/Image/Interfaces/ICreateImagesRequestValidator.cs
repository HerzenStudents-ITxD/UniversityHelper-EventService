using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.Image;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Validation.Image.Interfaces;

[AutoInject]
public interface ICreateImagesRequestValidator : IValidator<CreateImagesRequest>
{
}
