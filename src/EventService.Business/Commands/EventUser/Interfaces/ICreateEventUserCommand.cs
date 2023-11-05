using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.EventUser.Interfaces;

[AutoInject]
public interface ICreateEventUserCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(CreateEventUserRequest request);
}
