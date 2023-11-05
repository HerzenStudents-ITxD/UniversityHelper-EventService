using FluentValidation;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests.File;
using HerzenHelper.EventService.Validation.File.Interfaces;

namespace HerzenHelper.EventService.Validation.File;

public class RemoveFilesRequestValidator : AbstractValidator<RemoveFilesRequest>, IRemoveFilesRequestValidator
{
  public RemoveFilesRequestValidator(
    IFileRepository fileRepository)
  {
    RuleLevelCascadeMode = CascadeMode.Stop;

    RuleFor(request => request.FilesIds)
      .NotEmpty()
      .WithMessage("List of files ids must not be null or empty.");

    RuleFor(request => request)
      .MustAsync((x, _) => fileRepository.DoExistAsync(x.EntityId, x.FilesIds))
      .WithMessage("All file ids must belong to the same event.");
  }
}
