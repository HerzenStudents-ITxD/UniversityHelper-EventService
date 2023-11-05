using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.File;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.File.Interfaces;

[AutoInject]
public interface IFindFilesCommand
{
  Task<FindResultResponse<FileInfo>> ExecuteAsync(FindFilesFilter findFilter);
}
