using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Dtos;

public class CreateEventDto
{
    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Title { get; set; } = string.Empty;
    [Required] public DateTimeOffset Date { get; set; }
    [Required] public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}