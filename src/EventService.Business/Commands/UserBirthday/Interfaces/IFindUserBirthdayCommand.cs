using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.UserBirthday;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.Responses;

namespace UniversityHelper.EventService.Business.Commands.UserBirthday.Interfaces;

[AutoInject]
public interface IFindUserBirthdayCommand
{
  Task<FindResultResponse<UserBirthdayInfo>> ExecuteAsync(
    FindUsersBirthdaysFilter filter,
    CancellationToken cancellationToken = default);
}
