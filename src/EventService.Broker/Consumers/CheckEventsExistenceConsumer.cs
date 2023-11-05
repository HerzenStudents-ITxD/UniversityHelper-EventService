using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerzenHelper.Models.Broker.Common;
using HerzenHelper.EventService.Data.Interfaces;
using HerzenHelper.Core.BrokerSupport.Broker;
using MassTransit;

namespace HerzenHelper.EventService.Broker;

public class CheckEventsEntitiesExistenceConsumer : IConsumer<ICheckEventsExistence>
{
  private readonly IEventRepository _eventRepository;
  private readonly IEventCommentRepository _commentRepository;

  public CheckEventsEntitiesExistenceConsumer(
    IEventRepository eventRepository,
    IEventCommentRepository commentRepository)
  {
    _eventRepository = eventRepository;
    _commentRepository = commentRepository;
  }

  public async Task Consume(ConsumeContext<ICheckEventsExistence> context)
  {
    List<Guid> existingEvents = await _eventRepository.GetExisting(context.Message.EventsIds);
    List<Guid> existingComments = await _commentRepository.GetExisting(context.Message.EventsIds);
    object response = new();

    if (existingEvents.Any())
    {
      response = OperationResultWrapper.CreateResponse((_) => ICheckEventsExistence.CreateObj(existingEvents), context);
    }
    else if (existingComments.Any())
    {
      response = OperationResultWrapper.CreateResponse((_) => ICheckEventsExistence.CreateObj(existingComments), context);
    }
      
    await context.RespondAsync<IOperationResult<ICheckEventsExistence>>(response);
  }
}
