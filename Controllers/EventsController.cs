using EventPlanning.Dtos;
using EventPlanning.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanning.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController(IEventService service) : ControllerBase
{
    [Authorize(Policy = "CanManageProducts")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetAll()
    {
        return Ok(await service.GetAllAsync());
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<EventDto>> GetById(int id)
    {
        var product = await service.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }
    [HttpPost]
    public async Task<ActionResult<EventDto>> Create(CreateEventDto dto)
    {
        var created = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id },
            created);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await service.DeleteAsync(id);
        return NoContent();
    }
}