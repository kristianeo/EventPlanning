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
        CreateEvent createEvent = new CreateEvent()
        {
            Title = dto.Title,
            Date = dto.Date,
            Description = dto.Description,
            Location = dto.Location
        };

        Task<Event> result = repository.CreateAsync(createEvent);

        await result;
        
        logger.LogInformation("Creating event {Title} at {Date}",
            dto.Title, dto.Date);

        return result.Result.ToDto();
        
    }
    public Task<IEnumerable<EventDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    
    public Task<EventDto?> GetByIdAsync(int id)
    {
        logger.LogWarning("Product {ProductId} not found, returning empty result",
            id);
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}