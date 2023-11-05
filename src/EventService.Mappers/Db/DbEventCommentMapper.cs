using System;
using System.Collections.Generic;
using HerzenHelper.EventService.Mappers.Db.Interfaces;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.EventComment;

namespace HerzenHelper.EventService.Mappers.Db;

public class DbEventCommentMapper : IDbEventCommentMapper
{
  private readonly IDbImageMapper _imageMapper;

  public DbEventCommentMapper(
    IDbImageMapper imageMapper)
  {
    _imageMapper = imageMapper;
  }

  public DbEventComment Map(CreateEventCommentRequest request, List<Guid> imagesIds)
  {
    if (request is null)
    {
      return null;
    }

    Guid commentId = Guid.NewGuid();

    return new DbEventComment
    {
      Id = commentId,
      Content = request.Content,
      UserId = request.UserId,
      EventId = request.EventId,
      ParentId = request.ParentId,
      IsActive = true,
      CreatedAtUtc = DateTime.UtcNow,
      Images = imagesIds?.ConvertAll(imageId => _imageMapper.Map(imageId, commentId))
    };
  }
}
