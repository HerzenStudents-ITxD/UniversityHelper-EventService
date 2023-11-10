using System;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Business.Commands.EventUser.Interfaces;

[AutoInject]
public interface IEditEventUserCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid eventUserId, JsonPatchDocument<EditEventUserRequest> patch);
}
