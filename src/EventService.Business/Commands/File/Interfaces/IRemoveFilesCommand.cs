using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.File;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.File.Interfaces;

[AutoInject]
public interface IRemoveFilesCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(RemoveFilesRequest request);
}
