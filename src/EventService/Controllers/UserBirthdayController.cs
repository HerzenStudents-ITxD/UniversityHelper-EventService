using System.Threading;
using System.Threading.Tasks;
using UniversityHelper.EventService.Business.Commands.UserBirthday.Interfaces;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.UserBirthday;
using UniversityHelper.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace UniversityHelper.EventService.Controllers;

[Route("[controller]")]
[ApiController]
public class UserBirthdayController : ControllerBase
{
  [HttpGet("find")]
  public async Task<FindResultResponse<UserBirthdayInfo>> FindAsync(
    [FromServices] IFindUserBirthdayCommand command,
    [FromQuery] FindUsersBirthdaysFilter filter,
    CancellationToken cancellationToken)
  {
    return await command.ExecuteAsync(filter: filter, cancellationToken: cancellationToken);
  }
}
