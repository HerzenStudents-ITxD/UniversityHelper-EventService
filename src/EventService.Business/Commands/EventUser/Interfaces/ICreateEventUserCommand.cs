using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.EventUser.Interfaces;

[AutoInject]
public interface ICreateEventUserCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(CreateEventUserRequest request);
}
