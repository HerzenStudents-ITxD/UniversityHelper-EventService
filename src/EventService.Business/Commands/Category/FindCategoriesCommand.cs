using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Business.Commands.Category.Interfaces;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Mappers.Models.Interface;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.Category;

public class FindCategoriesCommand : IFindCategoriesCommand
{
  private readonly ICategoryRepository _categoryRepository;
  private readonly ICategoryInfoMapper _mapper;

  public FindCategoriesCommand(
    ICategoryRepository categoryRepository,
    ICategoryInfoMapper mapper)
  {
    _categoryRepository = categoryRepository;
    _mapper = mapper;
  }
  
  public async Task<FindResultResponse<CategoryInfo>> ExecuteAsync(
    FindCategoriesFilter filter, 
    CancellationToken cancellationToken = default)
  {
    (List<DbCategory> dbCategories, int totalCount) = await _categoryRepository.FindAsync(filter, cancellationToken);

    return new FindResultResponse<CategoryInfo>(
      body: dbCategories.ConvertAll(_mapper.Map),
      totalCount: totalCount);
  }
}

