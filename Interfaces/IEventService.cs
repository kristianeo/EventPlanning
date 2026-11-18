using EventPlanning.Dtos;

namespace EventPlanning.Interfaces;

public interface IEventService
{
        Task<IEnumerable<EventDto>> GetAllAsync();
        Task<EventDto?> GetByIdAsync(int id);
        Task<EventDto> CreateAsync(CreateEventDto dto);
        Task DeleteAsync(int id);
}