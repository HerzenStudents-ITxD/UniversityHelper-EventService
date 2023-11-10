using System.Threading.Tasks;
using UniversityHelper.Core.Attributes;

namespace UniversityHelper.EventService.Broker.Requests.Interfaces;

[AutoInject]
public interface IEmailService
{
  Task SendAsync(string email, string subject, string text);
}
