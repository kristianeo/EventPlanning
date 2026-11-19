using EventPlanning.Dtos;
using EventPlanning.Models;

namespace EventPlanning.Interfaces;

public interface IEventService
{
        Task<IEnumerable<EventDto>> GetAllAsync();
        Task<EventDto?> GetByIdAsync(int id);
        Task<EventDto> CreateAsync(CreateEventDto dto);
        Task<DeleteResult> DeleteAsync(int id);
        
        Task<IEnumerable<EventDto>> GetUserParticipations();
        Task<IEnumerable<EventDto>> GetOwnUserEvents();
        Task<IEnumerable<EventDto>> GetPublicEvents();
}

