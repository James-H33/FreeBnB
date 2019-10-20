using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Interfaces;
using Shared;

namespace Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
      if (userLoginDto == null)
      {
        return Unauthorized();
      }

      var token = await _authService.Login(userLoginDto);

      if (token != null)
      {
        return Ok(token);
      }

      return BadRequest("Username or Password is incorrect.");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserForRegister user)
    {
      if (user != null)
      {
        BadRequest("No content recieved.");
      }

      var userCreated =  await _authService.Register(user);

      if (!userCreated)
      {
        return BadRequest("Could not create user.");
      }

      return StatusCode(201, "User Created.");
    }
  }
}
