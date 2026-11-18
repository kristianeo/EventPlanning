using EventPlanning.Dtos;

namespace EventPlanning.Models;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int OwnerId { get; set; }
    public User Owner { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string? Description { get; set; }
}