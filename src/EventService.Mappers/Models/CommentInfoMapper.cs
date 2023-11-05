using HerzenHelper.EventService.Mappers.Models.Interface;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Models;

namespace HerzenHelper.EventService.Mappers.Models;

public class CommentInfoMapper : ICommentInfoMapper
{
  public CommentInfo Map(DbEventComment dbComment)
  {
    return dbComment is null
    ? null
    : new CommentInfo
    {
      Id = dbComment.Id,
      Content = dbComment.Content,
      UserId = dbComment.UserId,
      ParentId = dbComment.ParentId,
      Comment = new()
    };
  }
}
