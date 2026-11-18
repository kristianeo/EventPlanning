using EventPlanning.Interfaces;
using EventPlanning.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.Repositories;

public class EventRepository(EventDbContext context) : IEventRepository
{
    public async Task<IEnumerable<Event>> GetAllAsync() => 
        await context.Events.ToListAsync();

    public async Task<Event?> GetByIdAsync(int id) =>
        await context.Events.FindAsync(id);

    public async Task AddAsync(Event evt)
    {
        context.Events.Add(evt);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var evt = await context.Events.FindAsync(id);
        if (evt is not null)
        {
            context.Events.Remove(evt);
            await context.SaveChangesAsync();
        }
    }
}