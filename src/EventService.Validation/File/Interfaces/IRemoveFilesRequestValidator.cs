using FluentValidation;
using HerzenHelper.EventService.Models.Dto.Requests.File;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Validation.File.Interfaces;

[AutoInject]
public interface IRemoveFilesRequestValidator : IValidator<RemoveFilesRequest>
{
}
