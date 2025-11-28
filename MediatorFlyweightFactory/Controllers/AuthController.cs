using MediatorFlyweightFactory.Contracts.Requests;
using MediatorFlyweightFactory.Models;
using MediatorFlyweightFactory.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace MediatorFlyweightFactory.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(MyRegisterRequest dto)
    {
        User user = _userService.Register(dto.Email, dto.Password, dto.Role).Result;
        
        return Ok(user);
    }
}