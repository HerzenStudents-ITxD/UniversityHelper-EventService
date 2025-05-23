﻿using System;
using System.Collections.Generic;
using UniversityHelper.EventService.Models.Dto.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityHelper.EventService.Models.Db;

public class DbEvent
{
  public const string TableName = "Events";
  public Guid Id { get; set; }
  public bool IsActive { get; set; }
  public Guid CreatedBy { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public Guid? ModifiedBy { get; set; }
  public DateTime? ModifiedAtUtc { get; set; }

  public string Name { get; set; }
  public string Address { get; set; }
  public string Description { get; set; }
  public DateTime Date { get; set; }
  public DateTime? EndDate { get; set; }
  public FormatType Format { get; set; }
  public AccessType Access { get; set; }

  public ICollection<DbEventCategory> EventsCategories { get; set; }
  public ICollection<DbEventUser> Users { get; set; }
  
  public DbEvent()
  {
    EventsCategories = new HashSet<DbEventCategory>();
    Users = new HashSet<DbEventUser>();
  }

  public class DbEventConfiguration : IEntityTypeConfiguration<DbEvent>
  {
    public void Configure(EntityTypeBuilder<DbEvent> builder)
    {
      builder
        .ToTable(TableName);

      builder
        .HasKey(t => t.Id);

      builder
        .HasMany(e => e.EventsCategories)
        .WithOne(ec => ec.Event);

      builder
        .HasMany(e => e.Users)
        .WithOne(eu => eu.Event);
    }
  }
}
