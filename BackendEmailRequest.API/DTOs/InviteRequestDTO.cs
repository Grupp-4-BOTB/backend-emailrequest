namespace BackendEmailRequest.API.DTOs;

public class InviteRequestDTO
{

    public string RecipientEmail { get; set; } = string.Empty; //mottagaren
    public string InviterEmail { get; set; } //Perosnen som BJUDER IN ska också vara i samma grupp
    public int GroupId { get; set; } //Gruppen som man bjuds in till


    // DTON TRANSPORTERAR DET ANVÄNDAREN SKRIVER IN I PLACEHOLDERN, samt avsändaren och gruppen I FRONTEND OCH SKICKAR DET HIT TILL BACKEND
}
