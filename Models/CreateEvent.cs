namespace EventPlanning.Models;

public class CreateEvent
{
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public required string Location { get; set; }
    public string? Description { get; set; }
}