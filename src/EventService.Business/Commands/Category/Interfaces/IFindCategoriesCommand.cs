using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.Category;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.Category.Interfaces;

[AutoInject]
public interface IFindCategoriesCommand
{
  Task<FindResultResponse<CategoryInfo>> ExecuteAsync(
    FindCategoriesFilter filter,
    CancellationToken cancellationToken = default);
}

