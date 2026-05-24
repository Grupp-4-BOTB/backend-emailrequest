using Azure;
using Azure.Communication.Email;
using BackendEmailRequest.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BackendEmailRequest.Application.Services;


// INNEHÅLLER ENDAST EMAILET SOM SKICKAS UT TILL ANVÄNDAREN 
// Användare kan klicka in på sidan där dom väljer teacher eller student
public class EmailRequestService : IEmailRequestService
{
    private readonly string _connectionString;

    // Konstruktor som hämtar strängen från appsettings.json istället för att ha den här, annats kan andra skicka ut spam-mail som VI sen betalar för
    public EmailRequestService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("AzureEmailConnection") ?? string.Empty;
    }
    public async Task SendInviteEmailAsync(string recipientEmail, string inviterEmail, string acceptLink, string declineLink)
    {
        var emailClient = new EmailClient(_connectionString);

        var emailMessage = new EmailMessage(
            senderAddress: "DoNotReply@9cabc450-00b2-49d0-a006-889ff6ab5511.azurecomm.net",
            content: new EmailContent($"{inviterEmail} has invited you to a group.")
            {
                PlainText = $"{inviterEmail} has invited you to join their group!\nAccept: {acceptLink}\nDecline: {declineLink}",
                Html = $@"
                <html>
                    <body style='font-family: sans-serif; padding: 20px;'>
                        <p style='font-size: 16px;'><strong>{inviterEmail}</strong> has invited you to join their group.</p>
                        <p style='margin-bottom: 16px;'>Do you want to join?</p>
                        
                        <a href='{acceptLink}' style='padding: 12px 25px; background-color: #28a745; color: white; text-decoration: none; border-radius: 4px; font-weight: bold; margin-right: 15px; display: inline-block;'>Confirm</a>
                        
                        <a href='{declineLink}' style='padding: 12px 25px; background-color: #dc3545; color: white; text-decoration: none; border-radius: 4px; font-weight: bold; display: inline-block;'>Decline</a>
                    </body>
                </html>"
            },
            recipients: new EmailRecipients(new List<EmailAddress>
            {
                new EmailAddress(recipientEmail)
            }));

        await emailClient.SendAsync(WaitUntil.Completed, emailMessage);
    }
}