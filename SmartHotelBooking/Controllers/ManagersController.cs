using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using SmartHotelBooking.DTOs;

using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class ManagersController : ControllerBase
    {
        private readonly IAuthService _authService;
        public ManagersController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var response = await _authService.RegisterAsync(dto);
            return Ok(response);
        }
    }
}