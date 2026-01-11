using Application.Abstraction.Models.User;
using Application.Abstraction.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var userDto = await _userServices.Register(registerDto);
            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token =  await _userServices.Login(loginDto);
            return Ok(token);
        }
    }
}
