﻿using System;
using System.Collections.Generic;
using FluentValidation;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Enums;
using UniversityHelper.EventService.Models.Dto.Requests.EventUser;
using UniversityHelper.EventService.Validation.EventUser.Interfaces;
using UniversityHelper.EventService.Validation.EventUser.Resources;
using UniversityHelper.Core.BrokerSupport.AccessValidatorEngine.Interfaces;
using UniversityHelper.Core.Constants;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace UniversityHelper.EventService.Validation.EventUser;

public class EditEventUserRequestValidator : ExtendedEditRequestValidator<Guid, EditEventUserRequest>, IEditEventUserRequestValidator
{
  private readonly IEventUserRepository _eventUserRepository;
  private readonly IEventRepository _eventRepository;
  private readonly IAccessValidator _accessValidator;
  private readonly IHttpContextAccessor _httpContextAccessor;

  private void HandleInternalPropertyValidationAsync(
    Operation<EditEventUserRequest> requestedOperation,
    DbEvent dbEvent,
    EventUserStatus status,
    bool isAddEditRemoveUsers,
    bool isUser,
    ValidationContext<(Guid, JsonPatchDocument<EditEventUserRequest>)> context)
  {
    Context = context;
    RequestedOperation = requestedOperation;

    #region paths

    AddСorrectPaths(
      new List<string>
      {
        nameof(EditEventUserRequest.Status),
        nameof(EditEventUserRequest.NotifyAtUtc),
      });

    AddСorrectOperations(nameof(EditEventUserRequest.Status), new List<OperationType> { OperationType.Replace });
    AddСorrectOperations(nameof(EditEventUserRequest.NotifyAtUtc), new List<OperationType> { OperationType.Replace });

    #endregion

    #region Status

    AddFailureForPropertyIf(
      nameof(EditEventUserRequest.Status),
      x => x == OperationType.Replace,
      new Dictionary<Func<Operation<EditEventUserRequest>, bool>, string>
      {
        {
          x => Enum.TryParse(typeof(EventUserStatus), x.value?.ToString(), out _),
              EventUserRequestValidatorResource.IncorrectFormatStatus
        },
        {
          x => Enum.TryParse(x.value?.ToString(), out EventUserStatus newStatus) &&
              ((newStatus == EventUserStatus.Participant &&
                (((status == EventUserStatus.Refused || status == EventUserStatus.Invited) && isUser) ||
                  (status == EventUserStatus.Discarded && isAddEditRemoveUsers))) ||
               (newStatus == EventUserStatus.Refused &&
                  (status == EventUserStatus.Participant || status == EventUserStatus.Invited) && isUser) ||
                (newStatus == EventUserStatus.Discarded &&
                  status == EventUserStatus.Participant && isAddEditRemoveUsers)),
              EventUserRequestValidatorResource.NotHaveRightsToSetTheStaus
        }
      },
      CascadeMode.Stop);

    #endregion

    #region NotifyAtUtc

    AddFailureForPropertyIf(
      nameof(EditEventUserRequest.NotifyAtUtc),
      x => x == OperationType.Replace,
      new Dictionary<Func<Operation<EditEventUserRequest>, bool>, string>
      {
        {
          x => string.IsNullOrEmpty(x.value?.ToString().Trim()) ||
              (DateTime.TryParse(x.value.ToString().Trim(), out DateTime notifyAtUtc) &&
                notifyAtUtc < dbEvent.Date && notifyAtUtc > DateTime.UtcNow),
              EventUserRequestValidatorResource.IncorrectFormatNotifyAtUtc
        }
      });

    #endregion
  }

  public EditEventUserRequestValidator(
    IEventUserRepository eventUserRepository,
    IEventRepository eventRepository,
    IAccessValidator accessValidator,
    IHttpContextAccessor httpContextAccessor)
  {
    _eventUserRepository = eventUserRepository;
    _eventRepository = eventRepository;
    _accessValidator = accessValidator;
    _httpContextAccessor = httpContextAccessor;

    RuleFor(eventUserId => eventUserId.Item1)
      .MustAsync((eventUserId, _) => _eventUserRepository.DoesExistAsync(eventUserId))
      .WithMessage(EventUserRequestValidatorResource.EventUserIdDoesNotExist);

    RuleFor(paths => paths)
      .CustomAsync(async (paths, context, _) =>
      {
        DbEventUser dbEventUser = await _eventUserRepository.GetAsync(paths.Item1);
        DbEvent dbEvent = await _eventRepository.GetAsync(dbEventUser.EventId);
        bool isAddEditRemoveUsers = await _accessValidator.HasRightsAsync(Rights.AddEditRemoveUsers);
        bool isUser = _httpContextAccessor.HttpContext.GetUserId() == dbEventUser.UserId;

        foreach (var op in paths.Item2.Operations)
        {
          HandleInternalPropertyValidationAsync(
            requestedOperation: op,
            dbEvent: dbEvent,
            status: dbEventUser.Status,
            isAddEditRemoveUsers: isAddEditRemoveUsers,
            isUser: isUser,
            context: context);
        }
      });
  }
}
