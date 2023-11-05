using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Business.Commands.UserBirthday.Interfaces;
using HerzenHelper.EventService.Models.Dto.Models;
using HerzenHelper.EventService.Models.Dto.Requests.UserBirthday;
using HerzenHelper.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HerzenHelper.EventService.Controllers;

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
