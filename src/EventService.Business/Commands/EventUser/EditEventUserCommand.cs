using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using HerzenHelper.EventService.Business.Commands.EventUser.Interfaces;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.EventService.Mappers.Patch.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser;
using HerzenHelper.EventService.Validation.EventUser.Interfaces;
using HerzenHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using HerzenHelper.Core.Constants;
using HerzenHelper.Core.Extensions;
using HerzenHelper.Core.Helpers.Interfaces;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Business.Commands.EventUser;

public class EditEventUserCommand : IEditEventUserCommand
{
  private readonly IEditEventUserRequestValidator _validator;
  private readonly IEventUserRepository _eventUserRepository;
  private readonly IPatchDbEventUserMapper _mapper;
  private readonly IResponseCreator _responseCreator;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IHttpContextAccessor _contextAccessor;

  public EditEventUserCommand(
    IEditEventUserRequestValidator validator,
    IEventUserRepository eventUserRepository,
    IPatchDbEventUserMapper mapper,
    IResponseCreator responseCreator,
    IAccessValidator accessValidator,
    IHttpContextAccessor httpContextAccessor,
    IHttpContextAccessor contextAccessor)
  {
    _validator = validator;
    _eventUserRepository = eventUserRepository;
    _mapper = mapper;
    _responseCreator = responseCreator;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;
    _contextAccessor = contextAccessor;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(
    Guid eventUserId,
    JsonPatchDocument<EditEventUserRequest> patch)
  {
    Guid senderId = _httpContextAccessor.HttpContext.GetUserId();

    if (!await _accessValidator.HasRightsAsync(Rights.AddEditRemoveUsers) &&
        (await _eventUserRepository.GetAsync(eventUserId))?.UserId != senderId)
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }

    ValidationResult validationResult = await _validator.ValidateAsync((eventUserId, patch));

    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.BadRequest,
        validationResult.Errors.ConvertAll(er => er.ErrorMessage));
    }

    OperationResultResponse<bool> response = new(body : await _eventUserRepository.EditAsync(eventUserId, _mapper.Map(patch)));

    if (!response.Body)
    {
      _contextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }

    return response;
  }
}
