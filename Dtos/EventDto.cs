namespace EventPlanning.Dtos;

public class EventDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public UserDto Owner { get; set; } = null!;
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public string? Description { get; set; }
}