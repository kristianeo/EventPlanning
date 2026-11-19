using EventPlanning.Dtos;
using EventPlanning.Interfaces;
using EventPlanning.Models;
using EventPlanning.UserTest;

namespace EventPlanning.Services;

public class EventService(
    IEventRepository repository, 
    ILogger<EventService> logger,
    ICurrentUser currentUser) :IEventService
{
    public async Task<EventDto> CreateAsync(CreateEventDto dto)
    {
        logger.LogInformation("Creating event {Title} at {Date}",
            dto.Title, dto.Date);
        
        CreateEvent createEvent = new CreateEvent()
        {
            Title = dto.Title,
            Date = dto.Date.ToUniversalTime(),
            Description = dto.Description,
            Location = dto.Location,
            OwnerId = currentUser.UserId
        };

        Event evt = await repository.CreateAsync(createEvent);

        return evt.ToDto();
        
    }
    public async Task<IEnumerable<EventDto>> GetAllAsync()
    {
        var events = await repository.GetAllAsync();
        return events.Select(e => e.ToDto()).ToList();
    }
    
    public async Task<EventDto?> GetByIdAsync(int id)
    {
        Event? evt = await repository.GetByIdAsync(id);

        if (evt != null)
        {
            return evt.ToDto();
        }
        
        logger.LogWarning("Event {EventId} not found, returning empty result",
            id);
        return null;
    }

    public async Task<DeleteResult> DeleteAsync(int id)
    {
        var evt = await repository.GetByIdAsync(id);
        if (evt is null)
            return DeleteResult.NotFound;

        if (evt.OwnerId != currentUser.UserId)
        {
            logger.LogWarning("User {UserId} tried to delete event {EventId} owned by {OwnerId}",
                currentUser.UserId, id, evt.OwnerId);
            return DeleteResult.Forbidden;
        }

        await repository.DeleteAsync(id);
        return DeleteResult.Deleted;
    }

    public async Task<IEnumerable<EventDto>> GetUserParticipations()
    {
        var events = await repository.GetByOwnerAsync(currentUser.UserId);
        return events.Select(e => e.ToDto()).ToList();
    }

    public async Task<IEnumerable<EventDto>> GetOwnUserEvents()
    {
        var events = await repository.GetByOwnerAsync(currentUser.UserId);
        return events.Select(e => e.ToDto()).ToList();
    }

    public Task<IEnumerable<EventDto>> GetPublicEvents()
    {
        throw new NotImplementedException();
    }
}