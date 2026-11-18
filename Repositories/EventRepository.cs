using EventPlanning.Interfaces;
using EventPlanning.Models;
using EventPlanning.UserTest;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.Repositories;

public class EventRepository(
    EventDbContext context) : IEventRepository
{
    public async Task<IEnumerable<Event>> GetAllAsync() => 
        await context.Events
            .Include(e => e.Owner)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Event?> GetByIdAsync(int id) =>
        await context.Events
            .Include(e => e.Owner)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

    public async Task<Event> CreateAsync(CreateEvent createEvt)
    {
        Event evt = new Event()
        {
            Title = createEvt.Title,
            Date = createEvt.Date,
            Description = createEvt.Description,
            Location = createEvt.Location,
            OwnerId = createEvt.OwnerId
        };
        context.Events.Add(evt);
        await context.SaveChangesAsync();
        
        await context.Entry(evt).Reference(e => e.Owner).LoadAsync();

        return evt;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var evt = await context.Events.FindAsync(id);
        if (evt is not null)
        {
            context.Events.Remove(evt);
            await context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}