using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HerzenHelper.EventService.Models.Db;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Data.Interfaces
{
  [AutoInject]
  public interface IUserBirthdayRepository
  {
    Task UpdateUserBirthdayAsync(Guid userId, DateTime? dateOfBirth);
    Task<List<DbUserBirthday>> FindAsync(CancellationToken cancellationToken);
  }
}
