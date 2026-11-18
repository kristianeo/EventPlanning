using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Dtos;

public class CreateUserDto
{
    [Required] public string FirstName { get; set; } = string.Empty;
    [Required] public string LastName { get; set; } = string.Empty;
    [EmailAddress] public string? Email { get; set; }
}