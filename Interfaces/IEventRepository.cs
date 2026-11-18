using EventPlanning.Models;

namespace EventPlanning.Interfaces;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(int id);
    Task <Event> CreateAsync(CreateEvent createEvent);
    Task DeleteAsync(int id);

}