using UniversityHelper.EventService.Models.Db;
using UniversityHelper.Core.Attributes;
using UniversityHelper.Core.EFSupport.Provider;
using UniversityHelper.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace UniversityHelper.EventService.Data.Provider;

[AutoInject(InjectType.Scoped)]
public interface IDataProvider : IBaseDataProvider
{
  public DbSet<DbEvent> Events { get; set; }
  public DbSet<DbCategory> Categories { get; set; }
  public DbSet<DbCategoryColor> CategoryColors { get; set; }
  public DbSet<DbEventCategory> EventsCategories { get; set; }
  public DbSet<DbEventUser> EventsUsers { get; set; }
  public DbSet<DbUserBirthday> UsersBirthdays { get; set; }
}
