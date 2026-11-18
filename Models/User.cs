using EventPlanning.Dtos;

namespace EventPlanning.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    
    public string? Auth0Id { get; set; }

    public ICollection<Event> Owned { get; set; } = [];

    public ICollection<Participant> Participations { get; set; } = [];

    public UserDto ToDto()
    {
        return new UserDto
        {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            Email = Email
        };
    }
}