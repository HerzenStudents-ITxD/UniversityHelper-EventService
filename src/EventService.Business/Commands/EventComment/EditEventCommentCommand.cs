using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using UniversityHelper.EventService.Broker.Publishes.Interfaces;
using UniversityHelper.EventService.Business.Commands.EventComment.Interfaces;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Mappers.Patch.Interfaces;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.EventComment;
using UniversityHelper.EventService.Validation.EventComment.Interfaces;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Constants;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Business.Commands.EventComment;

public class EditEventCommentCommand : IEditEventCommentCommand
{
  private readonly IEditEventCommentRequestValidator _validator;
  private readonly IEventCommentRepository _repository;
  private readonly IPatchDbEventCommentMapper _mapper;
  private readonly IResponseCreator _responseCreator;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _contextAccessor;
  private readonly IPublish _publish;

  public EditEventCommentCommand(
    IEditEventCommentRequestValidator validator,
    IEventCommentRepository repository,
    IPatchDbEventCommentMapper mapper,
    IResponseCreator responseCreator,
    IAccessValidator accessValidator,
    IHttpContextAccessor contextAccessor,
    IPublish publish)
  {
    _validator = validator;
    _repository = repository;
    _mapper = mapper;
    _responseCreator = responseCreator;
    _accessValidator = accessValidator;
    _contextAccessor = contextAccessor;
    _publish = publish;
  }

  public async Task<OperationResultResponse<bool>> ExecuteAsync(
    Guid commentId,
    JsonPatchDocument<EditEventCommentRequest> request)
  {
    Guid senderId = _contextAccessor.HttpContext.GetUserId();

    ValidationResult validationResult = await _validator.ValidateAsync((commentId, request));

    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.BadRequest,
        validationResult.Errors.ConvertAll(er => er.ErrorMessage));
    }

    DbEventComment comment = await _repository.GetAsync(commentId);

    if (comment.UserId != senderId && !await _accessValidator.HasRightsAsync(Rights.AddEditRemoveUsers))
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.Forbidden);
    }

    OperationResultResponse<bool> response = new();

    object isActiveOperation = request.Operations.FirstOrDefault(o =>
        o.path.Equals("/" + nameof(EditEventCommentRequest.IsActive), StringComparison.OrdinalIgnoreCase))?.value;

    object contentOperation = request.Operations.FirstOrDefault(o =>
        o.path.Equals("/" + nameof(EditEventCommentRequest.Content), StringComparison.OrdinalIgnoreCase))?.value;

    if (isActiveOperation is not null && bool.TryParse(isActiveOperation.ToString(), out bool isActive) && !isActive)
    {
      (bool successfulEditing, List<Guid> filesIds, List<Guid> imagesIds) = await _repository.EditIsActiveAsync(commentId, _mapper.Map(request));

      if (successfulEditing)
      {
        if (filesIds.Any())
        {
          await _publish.RemoveFilesAsync(filesIds);
        }

        if (imagesIds.Any())
        {
          await _publish.RemoveImagesAsync(imagesIds);
        }
      }

      response.Body = successfulEditing;
    }
    else if (contentOperation is not null)
    {
      response.Body = await _repository.EditContentAsync(commentId, _mapper.Map(request));
    }
    else if (!response.Body)
    {
      return _responseCreator.CreateFailureResponse<bool>(HttpStatusCode.BadRequest);
    }

    return response;
  }
}
