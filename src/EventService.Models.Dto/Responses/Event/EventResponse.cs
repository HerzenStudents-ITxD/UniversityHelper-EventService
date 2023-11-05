﻿using System;
using System.Collections.Generic;
using HerzenHelper.EventService.Models.Dto.Enums;
using HerzenHelper.EventService.Models.Dto.Models;

namespace HerzenHelper.EventService.Models.Dto.Responses.Event;

public class EventResponse
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Address { get; set; }
  public string Description { get; set; }
  public DateTime Date { get; set; }
  public DateTime? EndDate { get; set; }
  public FormatType Format { get; set; }
  public AccessType Access { get; set; }
  public DateTime CreatedAtUtc { get; set; }
  public List<FileInfo> EventFiles { get; set; }
  public List<CategoryInfo> EventCategories { get; set; }
  public List<UserInfo> EventUsers { get; set; }
  public List<ImageInfo> EventImages { get; set; }
  public List<CommentInfo> EventComments { get; set; }
}
