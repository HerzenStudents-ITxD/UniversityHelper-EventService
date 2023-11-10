using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using UniversityHelper.EventService.Business.Commands.EventCategory.Interfaces;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Mappers.Db.Interfaces;
using UniversityHelper.EventService.Models.Dto.Requests.EventCategory;
using UniversityHelper.EventService.Validation.EventCategory.Interfaces;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Constants;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.Http;

namespace UniversityHelper.EventService.Business.Commands.EventCategory;

public class CreateEventCategoryCommand : ICreateEventCategoryCommand
{
  private readonly IAccessValidator _accessValidator;
  private readonly IEventCategoryRepository _repository;
  private readonly IDbEventCategoryMapper _mapper;
  private readonly ICreateEventCategoryRequestValidator _validator;
  private readonly IResponseCreator _responseCreator;
  private readonly IHttpContextAccessor _contextAccessor;

  public CreateEventCategoryCommand(
    IAccessValidator accessValidator,
    IEventCategoryRepository repository,
    IDbEventCategoryMapper mapper,
    ICreateEventCategoryRequestValidator validator,
    IResponseCreator responseCreator,
    IHttpContextAccessor contextAccessor)
  {
    _accessValidator = accessValidator;
    _repository = repository;
    _mapper = mapper;
    _validator = validator;
    _responseCreator = responseCreator;
    _contextAccessor = contextAccessor;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(CreateEventCategoryRequest request)
  {
    if (!await _accessValidator.HasRightsAsync(Rights.AddEditRemoveUsers))
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }

    request.CategoriesIds = request.CategoriesIds.Distinct().ToList();

    ValidationResult validationResult = await _validator.ValidateAsync(request);

    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<bool>(
        HttpStatusCode.BadRequest,
        validationResult.Errors.ConvertAll(er => er.ErrorMessage));
    }

    OperationResultResponse<bool> response = new();
    response.Body = await _repository.CreateAsync(_mapper.Map(request));
    
    if (!response.Body)
    {
      _contextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }

    _contextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

    return response;
  }
}
