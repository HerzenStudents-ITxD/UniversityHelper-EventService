using System;
using UniversityHelper.EventService.Mappers.Db.Interfaces;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace UniversityHelper.EventService.Mappers.Db
{
  public class DbCategoryMapper : IDbCategoryMapper
  {
    private readonly IHttpContextAccessor _contextAccessor;

    public DbCategoryMapper(IHttpContextAccessor accessor)
    {
      _contextAccessor = accessor;
    }

    public DbCategory Map(CreateCategoryRequest request)
    {
      return request is null
        ? null
        : new DbCategory
        {
          Id = Guid.NewGuid(),
          IsActive = true,
          Name = request.Name,
          Color = request.Color,
          CreatedBy = _contextAccessor.HttpContext.GetUserId(),
          CreatedAtUtc = DateTime.UtcNow
        };
    }
  }
}
