using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.Image;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.Image.Interfaces;

[AutoInject]
public interface IRemoveImageCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(RemoveImageRequest request);
}
