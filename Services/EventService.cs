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
        throw new NotImplementedException();
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