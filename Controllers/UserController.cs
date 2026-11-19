using EventPlanning.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanning.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    
}