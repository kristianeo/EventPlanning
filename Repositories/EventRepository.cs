using EventPlanning.Interfaces;
using EventPlanning.Models;
using EventPlanning.UserTest;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.Repositories;

public class EventRepository(
    EventDbContext context,
    ICurrentUser currentUser) : IEventRepository
{
    public async Task<IEnumerable<Event>> GetAllAsync() => 
        await context.Events.ToListAsync();

    public async Task<Event?> GetByIdAsync(int id) =>
        await context.Events.FindAsync(id);

    public async Task<Event> CreateAsync(CreateEvent createEvt)
    {
        Event evt = new Event()
        {
            Title = createEvt.Title,
            Date = createEvt.Date,
            Description = createEvt.Description,
            Location = createEvt.Location,
            OwnerId = currentUser.UserId
        };
        context.Events.Add(evt);
        await context.SaveChangesAsync();

        return evt;
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