using EventPlanning.Dtos;
using EventPlanning.Interfaces;
using EventPlanning.Models;

namespace EventPlanning.Services;

public class EventService(
    IEventRepository repository, 
    ILogger<EventService> logger) :IEventService
{
    public async Task<EventDto> CreateAsync(CreateEventDto dto)
    {
        logger.LogInformation("Creating event {Title} at {Date}",
            dto.Title, dto.Date);
        
        CreateEvent createEvent = new CreateEvent()
        {
            Title = dto.Title,
            Date = dto.Date,
            Description = dto.Description,
            Location = dto.Location
        };

        Event evt = await repository.CreateAsync(createEvent);

        return evt.ToDto();
        
    }
    public async Task<IEnumerable<EventDto>> GetAllAsync()
    {
        List<EventDto> eventDtos = [];
        eventDtos.AddRange(from evt in await repository.GetAllAsync() select evt.ToDto());

        return eventDtos;
    }
    
    public async Task<EventDto?> GetByIdAsync(int id)
    {
        Event? evt = await repository.GetByIdAsync(id);

        if (evt != null)
        {
            return evt.ToDto();
        }
        
        logger.LogWarning("Event {EventId} not found, returning empty result",
            id);
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
       return await repository.DeleteAsync(id);
    }
}