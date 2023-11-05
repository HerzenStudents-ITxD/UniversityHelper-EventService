using HerzenHelper.Core.BrokerSupport.Attributes;
using HerzenHelper.Models.Broker.Requests.User;
using HerzenHelper.EventService.Broker.Consumers;
using HerzenHelper.Core.BrokerSupport.Attributes;
using HerzenHelper.Core.BrokerSupport.Configurations;
using HerzenHelper.Models.Broker.Common;
using HerzenHelper.Models.Broker.Requests.Email;
using HerzenHelper.Models.Broker.Requests.File;
using HerzenHelper.Models.Broker.Requests.Image;
using HerzenHelper.Models.Broker.Requests.User;

namespace HerzenHelper.EventService.Broker.Configuration;

public class RabbitMqConfig : BaseRabbitMqConfig
{
  #region receive endpoints

  [MassTransitEndpoint(typeof(UpdateUserBirthdayConsumer))]
  public string UpdateUserBirthdayEndpoint { get; init; }

  [MassTransitEndpoint(typeof(CreateFilesConsumer))]
  public string CreateFilesEndpoint { get; init; }

  [MassTransitEndpoint(typeof(CheckEventsEntitiesExistenceConsumer))]
  public string CheckEventsEntitiesExistenceEndpoint { get; init; }

  #endregion

  // user

  [AutoInjectRequest(typeof(ICheckUsersExistence))]
  public string CheckUsersExistenceEndpoint { get; set; }

  [AutoInjectRequest(typeof(IGetUsersDataRequest))]
  public string GetUsersDataEndpoint { get; set; }

  [AutoInjectRequest(typeof(IFilteredUsersDataRequest))]
  public string FilteredUsersDataEndpoint { get; set; }

  [AutoInjectRequest(typeof(IGetUsersBirthdaysRequest))]
  public string GetUsersBirthdaysEndpoint { get; set; }

  //Email

  [AutoInjectRequest(typeof(ISendEmailRequest))]
  public string SendEmailEndpoint { get; set; }

  // file

  [AutoInjectRequest(typeof(IGetFilesRequest))]
  public string GetFilesEndpoint { get; init; }

  // image

  [AutoInjectRequest(typeof(ICreateImagesRequest))]
  public string CreateImagesEndpoint { get; init; }

  [AutoInjectRequest(typeof(IGetImagesRequest))]
  public string GetImagesEndpoint { get; init; }
}
