using System;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.EventUser;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Business.Commands.EventUser.Interfaces;

[AutoInject]
public interface IEditEventUserCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid eventUserId, JsonPatchDocument<EditEventUserRequest> patch);
}
