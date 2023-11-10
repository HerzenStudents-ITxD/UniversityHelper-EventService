using UniversityHelper.EventService.Mappers.Models.Interface;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;

namespace UniversityHelper.EventService.Mappers.Models;

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
