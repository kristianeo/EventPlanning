using EventPlanning.Models;

namespace EventPlanning.Interfaces;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(int id);
    Task AddAsync(Event product);
    Task DeleteAsync(int id);

}