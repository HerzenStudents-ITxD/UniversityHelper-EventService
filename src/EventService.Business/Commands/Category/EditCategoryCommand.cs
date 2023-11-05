using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using HerzenHelper.EventService.Business.Commands.Category.Interfaces;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.EventService.Mappers.Patch.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.EventService.Validation.Category.Interfaces;
using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using HerzenHelper.Core.Constants;
using HerzenHelper.Core.Helpers.Interfaces;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Business.Commands.Category;

public class EditCategoryCommand : IEditCategoryCommand
{
  private readonly IAccessValidator _accessValidator;
  private readonly IResponseCreator _responseCreator;
  private readonly ICategoryRepository _repository;
  private readonly IPatchDbCategoryMapper _mapper;
  private readonly IEditCategoryRequestValidator _validator;

  public EditCategoryCommand(
    IAccessValidator accessValidator,
    IResponseCreator responseCreator,
    ICategoryRepository repository,
    IPatchDbCategoryMapper mapper,
    IEditCategoryRequestValidator validator)
  {
    _accessValidator = accessValidator;
    _responseCreator = responseCreator;
    _repository = repository;
    _mapper = mapper;
    _validator = validator;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid categoryId, JsonPatchDocument<EditCategoryRequest> patch)
  {
    if (!await _accessValidator.HasRightsAsync(Rights.AddEditRemoveUsers))
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }

    ValidationResult validationResult = await _validator.ValidateAsync((categoryId, patch));

    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.BadRequest,
        validationResult.Errors.ConvertAll(er => er.ErrorMessage));
    }

    OperationResultResponse<bool> response = new(body: await _repository.EditAsync(categoryId, _mapper.Map(patch)));

    if (!response.Body)
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.BadRequest);
    }

    return response;
  }
}
