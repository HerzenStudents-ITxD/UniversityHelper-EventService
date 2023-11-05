using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.File;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.File.Interfaces;

[AutoInject]
public interface IRemoveFilesCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(RemoveFilesRequest request);
}
