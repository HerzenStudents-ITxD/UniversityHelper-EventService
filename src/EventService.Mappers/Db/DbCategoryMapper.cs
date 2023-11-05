using System;
using HerzenHelper.EventService.Mappers.Db.Interfaces;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace HerzenHelper.EventService.Mappers.Db
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
