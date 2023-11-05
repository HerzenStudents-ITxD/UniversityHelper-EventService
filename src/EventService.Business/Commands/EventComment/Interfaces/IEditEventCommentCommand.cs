using System;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.EventComment;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace HerzenHelper.EventService.Business.Commands.EventComment.Interfaces;

[AutoInject]
public interface IEditEventCommentCommand
{
  Task<OperationResultResponse<bool>> ExecuteAsync(Guid commentId, JsonPatchDocument<EditEventCommentRequest> patch);
}
