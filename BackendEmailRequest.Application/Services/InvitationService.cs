using BackendEmailRequest.Application.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackendEmailRequest.Application.Services;

public class InvitationService : IInvitationService
{
    private readonly HttpClient _httpClient;
    private readonly IEmailRequestService _emailService;

    public InvitationService(HttpClient httpClient, IEmailRequestService emailService)
    {
        _httpClient = httpClient;
        _emailService = emailService;
    }





    // SKRIVA CR FÖR CRUD PÅ DENNA SIDAN, SOM CHECKAR OM ANVÄNDARENS MAIL FINNS I DATABASEN (GABRIELS)
    // OCH OM ANVÄNDAREN EXISTERAR > GÅ VIDARE (CREATE) OCH SKICKAR UT MAILET.





    // READ - SÖKER EFTER ANVÄNDAREN I GABRIELS DATABAS

    public async Task DoesUserExistAsync(string recipientEmail)
    {
        // Göra ett HTTP anrop (GET) till Gabriels API
        var response = await _httpClient.GetAsync($"https://gabriels-api.com/api/users/{recipientEmail}"); //ÄNDRA TILL GABRIELS RIKTIGA API


        // Om Gabriel INTE svarar med 200 OK (användaren finns ej) -> Kasta felmeddelande direkt!
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("User does not exist.");
        }
    }




    // 2. CREATE - OM ANVÄNDAREN FINNS > SKICKA IVÄG MAIL FÖR INBJUDAN
    public async Task CreateGroupInvitationAsync(string recipientEmail, string inviterEmail, int groupId)
    {
        // 1. Kolla om användaren finns
        // await DoesUserExistAsync(recipientEmail); //KOMMENTERAR UT SÅLÄNGE

        var invitationId = Guid.NewGuid().ToString();



        // 2. Skicka mailet med länkarna direkt
        var acceptLink = $"https://lms-shiko.vercel.app/login?groupId={groupId}&invitationId={invitationId}"; //ANVÄÖNDAREN LOGGAR IN OCH GÅR MED I GRUPP
        var declineLink = "https://lms-shiko.vercel.app/"; //SKICKAR ANVÄNDAREN DIREKT TILL FÖRSTASIDAN OCH INBJUDAN NEKAS

        await _emailService.SendInviteEmailAsync(recipientEmail, inviterEmail, acceptLink, declineLink);
    }
}


