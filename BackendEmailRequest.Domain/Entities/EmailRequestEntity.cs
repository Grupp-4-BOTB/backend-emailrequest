using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendEmailRequest.Domain.Entities;


public class EmailRequestEntity
{


    //TAbellens rad ID
    [Key]
    public int Id { get; set; }


    //NYCKELN FÖR GRUPPEN
    [Required]
    public string InvitationId { get; set; }

    //ID FÖR GRUPPEN
    [Required]
    public int GroupId { get; set; }


    //Avsändaren
    [Required]
    public string InviterEmail { get; set; }


    // Mottagaren
    [Required]
    [EmailAddress]
    public string RecipientEmail { get; set; }


    //tID
    [Required]
    public DateTime SentAt { get; set; } = DateTime.UtcNow;

}