using EventPlanning.Models;

namespace EventPlanning.Interfaces;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(int id);
    Task <Event> CreateAsync(CreateEvent createEvent);
    Task<bool> DeleteAsync(int id);
    
    Task<IEnumerable<Event>> GetByOwnerAsync(int ownerId);
    
    Task<IEnumerable<Event>> GetUserParticipations(int userId);

}