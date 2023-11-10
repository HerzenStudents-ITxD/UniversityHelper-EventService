using FluentValidation;
using UniversityHelper.EventService.Models.Dto.Requests.File;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Validation.File.Interfaces;

[AutoInject]
public interface IRemoveFilesRequestValidator : IValidator<RemoveFilesRequest>
{
}
