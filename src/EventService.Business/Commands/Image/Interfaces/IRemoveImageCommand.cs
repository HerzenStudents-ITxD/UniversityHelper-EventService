using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.Image;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.Image.Interfaces;

[AutoInject]
public interface IRemoveImageCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(RemoveImageRequest request);
}
