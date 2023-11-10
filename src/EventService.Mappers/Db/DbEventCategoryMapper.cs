using System;
using System.Collections.Generic;
using System.Linq;
using UniversityHelper.EventService.Mappers.Db.Interfaces;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.EventCategory;
using UniversityHelper.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace UniversityHelper.EventService.Mappers.Db;

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
