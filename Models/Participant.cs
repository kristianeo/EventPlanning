namespace EventPlanning.Models;

public enum ParticipantStatus
{
    Invited,
    Going, 
    NotGoing,
    Maybe
}

public class Participant
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; } = null!;

    public string Email { get; set; } = null!;
    public int? UserId { get; set; }
    public User? User { get; set; }

    public ParticipantStatus Status { get; set; } = ParticipantStatus.Invited;
}