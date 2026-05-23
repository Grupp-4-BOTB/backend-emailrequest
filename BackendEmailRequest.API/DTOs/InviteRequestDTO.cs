namespace BackendEmailRequest.API.DTOs;

public class InviteRequestDTO
{

    public string RecipientEmail { get; set; } = string.Empty;


    // DTON TRANSPORTERAR DET ANVÄNDAREN SKRIVER IN I PLACEHOLDERN I FRONTEND OCH SKICKAT DET HIT TILL BACKEND
    // DET ÄR ALLTSÅ ENDAST FÖR DEN VI BJUDER IN I GRUPPEN
}
