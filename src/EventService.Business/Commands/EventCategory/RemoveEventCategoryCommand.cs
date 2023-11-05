using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using HerzenHelper.EventService.Business.Commands.EventCategory.Interfaces;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests.EventCategory;
using HerzenHelper.EventService.Validation.EventCategory.Interfaces;
using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using HerzenHelper.Core.Constants;
using HerzenHelper.Core.Helpers.Interfaces;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.Http;

namespace HerzenHelper.EventService.Business.Commands.EventCategory;

public class RemoveEventCategoryCommand : IRemoveEventCategoryCommand
{
  private readonly IHttpContextAccessor _contextAccessor;
  private readonly IAccessValidator _accessValidator;
  private readonly IEventCategoryRepository _repository;
  private readonly IRemoveEventCategoryRequestValidator _validator;
  private readonly IResponseCreator _responseCreator;

  public RemoveEventCategoryCommand(
    IHttpContextAccessor contextAccessor,
    IAccessValidator accessValidator,
    IEventCategoryRepository repository,
    IRemoveEventCategoryRequestValidator validator,
    IResponseCreator responseCreator)
  {
    _contextAccessor = contextAccessor;
    _accessValidator = accessValidator;
    _repository = repository;
    _validator = validator;
    _responseCreator = responseCreator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(RemoveEventCategoryRequest request)
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
        validationResult.Errors.ConvertAll(er => er.ErrorMessage));
    }

    OperationResultResponse<bool> response = new()
    {
      Body = await _repository.RemoveAsync(request.EventId, request.CategoriesIds)
    };

    if (!response.Body)
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.BadRequest);
    }

    _contextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;

    return response;
  }
}
