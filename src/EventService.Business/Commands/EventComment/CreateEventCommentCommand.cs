using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HerzenHelper.Models.Broker.Models.Image;
using FluentValidation.Results;
using HerzenHelper.EventService.Broker.Publishes.Interfaces;
using HerzenHelper.EventService.Broker.Requests.Interfaces;
using HerzenHelper.EventService.Business.Commands.EventComment.Interfaces;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.EventService.Mappers.Db.Interfaces;
using HerzenHelper.EventService.Models.Dto.Requests.EventComment;
using HerzenHelper.EventService.Validation.EventComment.Interfaces;
using HerzenHelper.Core.Helpers.Interfaces;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.Http;

namespace HerzenHelper.EventService.Business.Commands.EventComment;

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
