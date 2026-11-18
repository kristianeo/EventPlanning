namespace EventPlanning.Models;

public class CreateUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
}