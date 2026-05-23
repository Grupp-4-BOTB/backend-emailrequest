using BackendEmailRequest.API.DTOs;
using BackendEmailRequest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendEmailRequest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailRequestController : ControllerBase
{
    private readonly IEmailRequestService _emailService;

    public EmailRequestController(IEmailRequestService emailService)
    {
        _emailService = emailService;
    }





    // EMAIL INVITE
    // HANTERAR UTSÄNDNING AV EMAIL INBJUDAN TILL GRUPPEN

    [HttpPost("emailinvite")]
    public async Task<IActionResult> SendInvite([FromBody] InviteRequestDTO request) // inviteRequestDTO innehåller toEmail
    {
        // 1. HAR HÅRDKODAT MAILEN SOM ANVÄNDAREN FÅR I MAILET SÅLÄNGE! (Byta ut mot att den som skickade inbjudan sen ska stå här.)
        string inviterEmail = "SAMUEL JOHANSSON";

        // 2. VERCEL-länken som kopplar användarens email med sidan så sidan vet vem som går in
        string inviteLink = $"https://lms-shiko.vercel.app/emailverification?email={request.RecipientEmail}";

        // 3. Skicka till din service
        await _emailService.SendInviteEmailAsync(request.RecipientEmail, inviterEmail, inviteLink);

        return Ok(new { message = "The invite has been sent to email!" }); //skrivs ut när mailet skickats iväg på frontend
    }
}


