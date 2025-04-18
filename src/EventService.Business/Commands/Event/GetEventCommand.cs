﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.Models.Broker.Models.User;
using UniversityHelper.EventService.Broker.Requests.Interfaces;
using UniversityHelper.EventService.Business.Commands.Event.Interfaces;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Mappers.Models.Interface;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.Event;
using UniversityHelper.EventService.Models.Dto.Responses.Event;
using UniversityHelper.Core.Helpers.Interfaces;
using UniversityHelper.Core.Responses;
using UniversityHelper.Models.Broker.Models.File;

namespace UniversityHelper.EventService.Business.Commands.Event;

public class GetEventCommand : IGetEventCommand
{
  private readonly IEventRepository _repository;
  private readonly IEventResponseMapper _mapper;
  private readonly IResponseCreator _responseCreator;
  private readonly IImageService _imageService;
  private readonly IUserService _userService;
  private readonly IFileService _fileService;
  private readonly ICommentInfoMapper _commentInfoMapper;

  public GetEventCommand(
    IEventRepository repository,
    IEventResponseMapper mapper,
    IResponseCreator responseCreator,
    IImageService imageService,
    IUserService userService,
    IFileService fileService,
    ICommentInfoMapper commentInfoMapper)
  {
    _repository = repository;
    _mapper = mapper;
    _responseCreator = responseCreator;
    _imageService = imageService;
    _userService = userService;
    _fileService = fileService;
    _commentInfoMapper = commentInfoMapper;
  }

  public async Task<OperationResultResponse<EventResponse>> ExecuteAsync(GetEventFilter filter, CancellationToken ct)
  {
    DbEvent dbEvent = await _repository.GetAsync(filter.EventId, filter);

    if (dbEvent is null)
    {
      return _responseCreator.CreateFailureResponse<EventResponse>(HttpStatusCode.NotFound);
    }

    Task<List<FileCharacteristicsData>> filesTask = filter.IncludeFiles
      ? _fileService.GetFilesCharacteristicsAsync(dbEvent.Files.Select(f => f.FileId).ToList())
      : Task.FromResult(null as List<FileCharacteristicsData>);

    Task<List<UserData>> usersTask = filter.IncludeUsers
      ? _userService.GetUsersDataAsync(dbEvent.Users.Select(u => u.UserId).ToList())
      : Task.FromResult(null as List<UserData>);

    Task<List<ImageInfo>> imagesTask = filter.IncludeImages
      ? _imageService.GetImagesAsync(dbEvent.Images.Select(i => i.ImageId).ToList())
      : Task.FromResult(null as List<ImageInfo>);

    List<FileCharacteristicsData> files = await filesTask;
    List<UserData> users = await usersTask;
    List<ImageInfo> images = await imagesTask;

    List<CommentInfo> comments = null;

    if (filter.IncludeComments)
    {
      comments = dbEvent.Comments.Select(_commentInfoMapper.Map).ToList();

      foreach (CommentInfo comment in comments)
      {
        comment.Comment.AddRange(comments.Where(c => c.ParentId == comment.Id));
      }

      comments.RemoveAll(x => x.ParentId is not null);
    }

    return new OperationResultResponse<EventResponse>
    {
      Body = _mapper.Map(
        dbEvent: dbEvent,
        usersData: users,
        images: images,
        files: files,
        comments: comments)
    };
  }
}
