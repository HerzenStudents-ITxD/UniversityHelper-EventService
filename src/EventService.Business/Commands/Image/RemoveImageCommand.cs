using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using HerzenHelper.EventService.Broker.Publishes.Interfaces;
using HerzenHelper.EventService.Business.Commands.Image.Interfaces;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests.Image;
using HerzenHelper.EventService.Validation.Image.Interfaces;
using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using HerzenHelper.Core.Constants;
using HerzenHelper.Core.Helpers.Interfaces;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.Image;

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
