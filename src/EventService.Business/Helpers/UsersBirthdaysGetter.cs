using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerzenHelper.Models.Broker.Models.User;
using HerzenHelper.EventService.Broker.Requests.Interfaces;
using HerzenHelper.EventService.Data.Provider.MsSql.Ef;
using HerzenHelper.EventService.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HerzenHelper.EventService.Business.Helpers
{
  public class UsersBirthdaysGetter
  {
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IUserService _userService;

    private async Task ExecuteAsync()
    {
      using var scope = _scopeFactory.CreateScope();
      using var dbContext = scope.ServiceProvider.GetRequiredService<EventServiceDbContext>();

      List<Guid> users = await dbContext.UsersBirthdays.Select(ub => ub.UserId).ToListAsync();

      if (users.Any())
      {
        return;
      }

      List<UserBirthday> usersBirthdays = await _userService.GetUsersBirthdaysAsync();

      if (usersBirthdays is null || !usersBirthdays.Any())
      {
        return;
      }

      dbContext.UsersBirthdays.AddRange(
        usersBirthdays.Where(ub => !users.Contains(ub.UserId)).Select(ub => new DbUserBirthday
        {
          UserId = ub.UserId,
          DateOfBirth = ub.DateOfBirth,
          IsActive = true,
          CreatedAtUtc = DateTime.UtcNow
        }));

      await dbContext.SaveChangesAsync();
    }

    public UsersBirthdaysGetter(
      IServiceScopeFactory scopeFactory,
      IUserService userService)
    {
      _scopeFactory = scopeFactory;
      _userService = userService;
    }

    public void Start()
    {
      Task.Run(async () =>
      {
        await ExecuteAsync();
      });
    }
  }
}
