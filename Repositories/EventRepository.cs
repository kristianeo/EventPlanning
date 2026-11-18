using EventPlanning.Interfaces;
using EventPlanning.Models;

namespace EventPlanning.Repositories;

public class EventRepository(EventDbContext context) : IEventRepository
{
    public Task<IEnumerable<Event>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Event?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Event product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}