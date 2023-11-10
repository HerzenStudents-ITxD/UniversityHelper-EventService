using System;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.EventComment;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace UniversityHelper.EventService.Business.Commands.EventComment.Interfaces;

[AutoInject]
public interface IEditEventCommentCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid commentId, JsonPatchDocument<EditEventCommentRequest> patch);
}
