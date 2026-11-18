using EventPlanning.Dtos;
using EventPlanning.Interfaces;

namespace EventPlanning.Services;

public class EventService(IEventRepository repository) :IEventService
{
    public async Task<EventDto> CreateAsync(CreateEventDto dto)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<EventDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EventDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}