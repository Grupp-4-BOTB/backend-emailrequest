using Azure.Messaging.ServiceBus;
using BackendEmailRequest.API.DTOs;
using BackendEmailRequest.Application.Interfaces;
using BackendEmailRequest.Domain.Entities;
using BackendEmailRequest.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BackendEmailRequest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailRequestController : ControllerBase
{

    private readonly IInvitationService _invitationService;
    private readonly EmailRequestDbContext _context;
    private readonly IConfiguration _configuration;

    public EmailRequestController(IInvitationService invitationService, EmailRequestDbContext context, IConfiguration configuration)
    {
        _invitationService = invitationService;
        _context = context;
        _configuration = configuration;
    }









    

    [HttpPost("emailinvite")]
    public async Task<IActionResult> SendInvite([FromBody] InviteRequestDTO request)
    {
        
        // 1. HÅRDKODAT NAMNET PÅ AVSÄNDAREN FOR NOW, ÄNDRAS SEN.
       // string inviterEmail = "SAMUEL JOHANSSON";

        // Istäklet för den hårdkodade Samuel ovanför använder jag nedan (Om Gabriel inte hinner klart med sin databas använder jag SAMUEL JOHANSSON ovan och kommenterar ut dom två nedan.!
        string inviterEmail = request.InviterEmail;
        int groupId = request.GroupId;







        // Skapa ID för inbjudan här, EN GUID SKAPAS för invitationId i databasen
        // Kopplar ihop rätt inbjudan med rätt person
        var invitationId = Guid.NewGuid().ToString();


        // SPARAR TILL MIN DATABAS
        var newInvitation = new EmailRequestEntity
        {
            InvitationId = invitationId,
            RecipientEmail = request.RecipientEmail,
            InviterEmail = inviterEmail,
            GroupId = groupId,
        };

        _context.EmailRequests.Add(newInvitation);
        await _context.SaveChangesAsync();









        // Service Busen för team invite (Hans skrev sin i Program.cs men jag skrev den I MANAGE SECRETS istället för sekretess)
        string? serviceBusConnection = _configuration.GetConnectionString("ServiceBusConnection");

        await using var client = new ServiceBusClient(serviceBusConnection);
        var sender = client.CreateSender("groupinvite-queue");

        // Paketerar upp i JSON och skickar in i kön
        var body = JsonSerializer.Serialize(new { request.RecipientEmail, inviterEmail, groupId });
        await sender.SendMessageAsync(new ServiceBusMessage(body));




        //ANROPAR GABRIELS  FÖR ANVÄNDARE.
        // OM ANVÄNDARE EXISTERAR SÅ SKICKAS MAIL UT
        await _invitationService.CreateGroupInvitationAsync(request.RecipientEmail, inviterEmail, groupId);

        return Ok(new { message = "The invite has been processed and sent!" });
    }
}