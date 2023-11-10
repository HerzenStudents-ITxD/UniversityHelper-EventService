using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using UniversityHelper.EventService.Broker.Publishes.Interfaces;
using UniversityHelper.EventService.Business.Commands.Image.Interfaces;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Models.Dto.Requests.Image;
using UniversityHelper.EventService.Validation.Image.Interfaces;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Constants;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.Image;

public class RemoveImageCommand : IRemoveImageCommand
{
  private readonly IImageRepository _repository;
  private readonly IAccessValidator _accessValidator;
  private readonly IRemoveImagesRequestValidator _validator;
  private readonly IResponseCreator _responseCreator;
  private readonly IPublish _publish;

  public RemoveImageCommand(
    IImageRepository repository,
    IAccessValidator accessValidator,
    IRemoveImagesRequestValidator validator,
    IResponseCreator responseCreator,
    IPublish publish)
  {
    _repository = repository;
    _accessValidator = accessValidator;
    _validator = validator;
    _responseCreator = responseCreator;
    _publish = publish;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(RemoveImageRequest request)
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

    OperationResultResponse<bool> response = new();

    response.Body = await _repository.RemoveAsync(request.ImagesIds);

    if (response.Body)
    {
      await _publish.RemoveImagesAsync(request.ImagesIds);
    }

    return response;
  }
}
