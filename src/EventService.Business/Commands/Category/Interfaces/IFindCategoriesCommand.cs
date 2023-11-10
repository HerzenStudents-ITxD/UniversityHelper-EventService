using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.Category;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.Category.Interfaces;

[AutoInject]
public interface IFindCategoriesCommand
{
  Task<FindResultResponse<CategoryInfo>> ExecuteAsync(
    FindCategoriesFilter filter,
    CancellationToken cancellationToken = default);
}

