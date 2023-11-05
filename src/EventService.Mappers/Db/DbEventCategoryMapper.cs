using System;
using System.Collections.Generic;
using System.Linq;
using HerzenHelper.EventService.Mappers.Db.Interfaces;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.EventCategory;
using HerzenHelper.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace HerzenHelper.EventService.Mappers.Db;

public class DbEventCategoryMapper : IDbEventCategoryMapper
{
  private readonly IHttpContextAccessor _contextAccessor;

  public DbEventCategoryMapper(IHttpContextAccessor accessor)
  {
    _contextAccessor = accessor;
  }

  public List<DbEventCategory> Map(CreateEventCategoryRequest request)
  {
    return request is null
      ? null
      : request.CategoriesIds.Select(categoryId => new DbEventCategory
      {
        Id = Guid.NewGuid(),
        EventId = request.EventId,
        CategoryId = categoryId,
        CreatedBy = _contextAccessor.HttpContext.GetUserId(),
        CreatedAtUtc = DateTime.UtcNow
      }).ToList();
  }
}
