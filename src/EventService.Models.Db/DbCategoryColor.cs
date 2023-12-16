using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityHelper.EventService.Models.Dto.Enums;

namespace UniversityHelper.EventService.Models.Db;
public class DbCategoryColor
{
  public const string TableName = "CategoryColors";

  public Guid Id { get; set; }
  public bool IsActive { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public Guid? ModifiedBy { get; set; }
  public DateTime? ModifiedAtUtc { get; set; }

  public Guid UniversityId { get; set; }
  public string Name { get; set; }
  public byte R { get; set; }
  public byte G { get; set; }
  public byte B { get; set; }
  public float A { get; set; }

  public ICollection<DbCategory> Categories { get; set; }
}

public class DbCategoryColorConfiguration : IEntityTypeConfiguration<DbCategoryColor>
{
  public void Configure(EntityTypeBuilder<DbCategoryColor> builder)
  {
    builder
      .ToTable(DbCategoryColor.TableName);

    builder
      .HasKey(t => t.Id);

    builder
      .HasMany(e => e.Categories)
      .WithOne(ec => ec.Color);
  }
}

