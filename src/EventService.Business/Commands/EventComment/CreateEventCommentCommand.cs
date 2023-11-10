using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniversityHelper.Models.Broker.Models.Image;
using FluentValidation.Results;
using UniversityHelper.EventService.Broker.Publishes.Interfaces;
using UniversityHelper.EventService.Broker.Requests.Interfaces;
using UniversityHelper.EventService.Business.Commands.EventComment.Interfaces;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Mappers.Db.Interfaces;
using UniversityHelper.EventService.Models.Dto.Requests.EventComment;
using UniversityHelper.EventService.Validation.EventComment.Interfaces;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.Http;

namespace UniversityHelper.EventService.Business.Commands.EventComment;

public class CreateEventCommentCommand : ICreateEventCommentCommand
{
  private readonly IEventCommentRepository _repository;
  private readonly ICreateEventCommentRequestValidator _validator;
  private readonly IDbEventCommentMapper _mapper;
  private readonly IResponseCreator _responseCreator;
  private readonly IHttpContextAccessor _contextAccessor;
  private readonly IImageService _imageService;
  private readonly IPublish _publish;

  private const int ResizeMaxValue = 1000;
  private const int ConditionalWidth = 4;
  private const int ConditionalHeight = 3;

  public CreateEventCommentCommand(
    IEventCommentRepository repository,
    ICreateEventCommentRequestValidator validator,
    IDbEventCommentMapper mapper,
    IResponseCreator responseCreator,
    IHttpContextAccessor contextAccessor,
    IImageService imageService,
    IPublish publish)
  {
    _repository = repository;
    _mapper = mapper;
    _validator = validator;
    _responseCreator = responseCreator;
    _contextAccessor = contextAccessor;
    _imageService = imageService;
    _publish = publish;
  }

  public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateEventCommentRequest request)
  {
    ValidationResult validationResult = await _validator.ValidateAsync(request);
    if (!validationResult.IsValid)
    {
      return _responseCreator.CreateFailureResponse<Guid?>(
        HttpStatusCode.BadRequest,
        validationResult.Errors.ConvertAll(er => er.ErrorMessage));
    }

    OperationResultResponse<Guid?> response = new();

    List<Guid> imagesIds = null;
    if (request.CommentImages is not null && request.CommentImages.Any())
    {
      imagesIds = await _imageService.CreateImagesAsync(
        request.CommentImages,
        new ResizeParameters(
          maxResizeValue: ResizeMaxValue,
          maxSizeCompress: null,
          previewParameters: new PreviewParameters(
            conditionalWidth: ConditionalWidth,
            conditionalHeight: ConditionalHeight,
            resizeMaxValue: null,
            maxSizeCompress: null)),
        response.Errors);
    }
    
    response.Body = await _repository.CreateAsync(_mapper.Map(request, imagesIds));

    if (response.Body is not null)
    {
      _contextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
    }
    else
    {
      await _publish.RemoveImagesAsync(imagesIds);

      _contextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }

    return response;
  }
}
