using System;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Requests.EventComment;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.EventComment.Interfaces;

[AutoInject]
public interface ICreateEventCommentCommand
{
  Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateEventCommentRequest request);
}
