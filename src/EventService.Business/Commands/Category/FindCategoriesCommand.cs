using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Business.Commands.Category.Interfaces;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.EventService.Mappers.Models.Interface;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.Category;

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

