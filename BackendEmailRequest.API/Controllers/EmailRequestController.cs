using BackendEmailRequest.API.DTOs;
using BackendEmailRequest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendEmailRequest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailRequestController : ControllerBase
{
    private readonly IInvitationService _invitationService;

    public EmailRequestController(IInvitationService invitationService)
    {
        _invitationService = invitationService;
    }









    

    [HttpPost("emailinvite")]
    public async Task<IActionResult> SendInvite([FromBody] InviteRequestDTO request)
    {
        
        // 1. HÅRDKODAT NAMNET PÅ AVSÄNDAREN FOR NOW, ÄNDRAS SEN
        string inviterEmail = "SAMUEL JOHANSSON";




        //ANROPAR GABRIELS  FÖR ANVÄNDARE.
        // OM ANVÄNDARE EXISTERAR SÅ SKICKAS MAIL UT
        await _invitationService.CreateGroupInvitationAsync(request.RecipientEmail, inviterEmail);

        return Ok(new { message = "The invite has been processed and sent!" });
    }
}