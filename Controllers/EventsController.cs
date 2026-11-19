using EventPlanning.Dtos;
using EventPlanning.Interfaces;
using EventPlanning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanning.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController(IEventService service) : ControllerBase
{
    [Authorize(Policy = "CanViewAll")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetAll()
    {
        return Ok(await service.GetAllAsync());
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<EventDto>> GetById(int id)
    {
        var evt = await service.GetByIdAsync(id);
        return evt is null ? NotFound() : Ok(evt);
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
        return await service.DeleteAsync(id) switch
        {
            DeleteResult.Deleted   => NoContent(),
            DeleteResult.NotFound  => NotFound(),
            DeleteResult.Forbidden => Forbid(),
            _ => StatusCode(500)
        };
    }
}