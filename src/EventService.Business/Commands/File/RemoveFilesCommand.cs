using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using HerzenHelper.EventService.Broker.Publishes.Interfaces;
using HerzenHelper.EventService.Business.Commands.File.Interfaces;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests.File;
using HerzenHelper.EventService.Validation.File.Interfaces;
using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using HerzenHelper.Core.Constants;
using HerzenHelper.Core.Helpers.Interfaces;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.File;

public class RemoveFilesCommand : IRemoveFilesCommand
{
  private readonly IFileRepository _repository;
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly IPublish _publish;
  private readonly IRemoveFilesRequestValidator _validator;

  public RemoveFilesCommand(
    IFileRepository repository,
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    IPublish publish,
    IRemoveFilesRequestValidator validator)
  {
    _repository = repository;
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _publish = publish;
    _validator = validator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(RemoveFilesRequest request)
  {
    if (!await _accessValidator.HasRightsAsync(Rights.AddEditRemoveUsers))
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }

    ValidationResult validationResult = await _validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<bool>(
        HttpStatusCode.BadRequest,
        validationResult.Errors.ConvertAll(x => x.ErrorMessage));
    }

    OperationResultResponse<bool> response = new(body: await _repository.RemoveAsync(request.FilesIds));

    if (response.Body)
    {
      await _publish.RemoveFilesAsync(request.FilesIds);
    }
    else
    {
      response = _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.BadRequest, response.Errors);
    }

    return response;
  }
}
