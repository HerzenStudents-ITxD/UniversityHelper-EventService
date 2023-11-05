using System;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Requests.EventComment;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.EventComment.Interfaces;

[AutoInject]
public interface ICreateEventCommentCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateEventCommentRequest request);
}
