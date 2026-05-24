using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendEmailRequest.Domain.Entities;


public class EmailRequestEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string SenderEmail { get; set; }

    [Required]
    [EmailAddress]
    public string RecipientEmail { get; set; }

    [Required]
    public DateTime SentAt { get; set; } = DateTime.UtcNow;

}