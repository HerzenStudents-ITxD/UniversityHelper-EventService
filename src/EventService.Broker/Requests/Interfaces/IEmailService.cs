using System.Threading.Tasks;
using HerzenHelper.Core.Attributes;

namespace HerzenHelper.EventService.Broker.Requests.Interfaces;

[AutoInject]
public interface IEmailService
{
  Task SendAsync(string email, string subject, string text);
}
