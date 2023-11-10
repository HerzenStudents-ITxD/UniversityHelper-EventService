using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.File;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.File.Interfaces;

[AutoInject]
public interface IFindFilesCommand
{
  Task<FindResultResponse<FileInfo>> ExecuteAsync(FindFilesFilter findFilter);
}
