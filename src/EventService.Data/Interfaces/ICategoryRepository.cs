﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Enums;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.Core.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Data.Interfaces;

[AutoInject]
public interface ICategoryRepository
{
  Task<bool> DoExistAllAsync(List<Guid> categoriesIds);
  Task<bool> DoesExistAsync(string name, CategoryColor color);
  Task<Guid?> CreateAsync(DbCategory dbCategory);
  Task CreateAsync(List<DbCategory> dbCategories);
  Task<(List<DbCategory> dbCategories, int totalCount)> FindAsync(
    FindCategoriesFilter filter,
    CancellationToken cancellationToken = default);
  Task<bool> EditAsync(Guid categoryId, JsonPatchDocument<DbCategory> request);
}
