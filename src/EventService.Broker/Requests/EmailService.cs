using System.Threading.Tasks;
using HerzenHelper.EventService.Broker.Requests.Interfaces;
using HerzenHelper.Core.BrokerSupport.Helpers;
using HerzenHelper.Models.Broker.Requests.Email;
using MassTransit;

namespace HerzenHelper.EventService.Broker.Requests;

public class EmailService : IEmailService
{
  private readonly IRequestClient<ISendEmailRequest> _rcSendEmail;

  public EmailService(IRequestClient<ISendEmailRequest> rcSendEmail)
  {
    _rcSendEmail = rcSendEmail;
  }

  public async Task SendAsync(string email, string subject, string text)
  {
    await _rcSendEmail.ProcessRequest<ISendEmailRequest, bool>(
      ISendEmailRequest.CreateObj(
        email,
        subject,
        text));
  }
}
