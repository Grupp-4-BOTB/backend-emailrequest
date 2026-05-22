using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendEmailRequest.Domain.Entities;

public class InviteEmailEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string GroupId { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty; // Hit skickas mailet via Service Bus

    [Required]
    public string Role { get; set; } = "Student"; // Rollen de får när de accepterar

    [Required]
    public string Status { get; set; } = "Pending"; // "Pending", "Accepted", "Denied"

}

