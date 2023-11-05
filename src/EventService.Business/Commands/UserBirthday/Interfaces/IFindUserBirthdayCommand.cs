using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.UserBirthday;
using HerzenHelper.Core.Attributes;
using HerzenHelper.Core.Responses;

namespace HerzenHelper.EventService.Business.Commands.UserBirthday.Interfaces;

[AutoInject]
public interface IFindUserBirthdayCommand
{
  Task<FindResultResponse<UserBirthdayInfo>> ExecuteAsync(
    FindUsersBirthdaysFilter filter,
    CancellationToken cancellationToken = default);
}
