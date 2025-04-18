﻿using UniversityHelper.EventService.Mappers.Patch.Interfaces;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace UniversityHelper.EventService.Mappers.Patch;

public class PatchDbCategoryMapper : IPatchDbCategoryMapper
{
  public JsonPatchDocument<DbCategory> Map(JsonPatchDocument<EditCategoryRequest> request)
  {
    if (request is null)
    {
      return null;
    }

    JsonPatchDocument<DbCategory> dbCategoryPatch = new();

    foreach (Operation<EditCategoryRequest> item in request.Operations)
    {
      dbCategoryPatch.Operations.Add(new Operation<DbCategory>(
        item.op,
        item.path,
        item.from,
        string.IsNullOrEmpty(item.value?.ToString().Trim())
          ? null
          : item.value.ToString().Trim()));
    }

    return dbCategoryPatch;
  }
}
