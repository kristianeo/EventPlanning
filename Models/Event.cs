using EventPlanning.Dtos;

namespace EventPlanning.Models;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int OwnerId { get; set; }
    public User Owner { get; set; } = null!;
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public string? Description { get; set; }

    public ICollection<Participant> Participants { get; set; } = [];

    public EventDto ToDto()
    {
        return new EventDto
        {
            Id = Id,
            Title = Title,
            Owner = Owner.ToDto(),
            Date = Date,
            Location = Location,
            Description = Description
        };
    }
}