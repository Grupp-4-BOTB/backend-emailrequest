using System.Threading.Tasks;

namespace BackendEmailRequest.Application.Interfaces;

public interface IEmailRequestService
{
    Task SendInviteEmailAsync(string recipientEmail, string inviterEmail, string acceptLink, string declineLink);
}