using System.Threading.Tasks;

namespace BackendEmailRequest.Application.Interfaces;

public interface IInvitationService
{
    Task CreateGroupInvitationAsync(string recipientEmail, string inviterEmail);
}