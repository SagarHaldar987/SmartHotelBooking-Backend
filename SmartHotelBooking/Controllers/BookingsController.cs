using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowFrontend")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // ✅ Secure Create Booking - attaches userId from token
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create(CreateBookingDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("User ID not found in token.");

            int userId = int.Parse(userIdClaim.Value);
            var result = await _bookingService.CreateBookingAsync(dto, userId);
            return Ok(result);
        }

        // ✅ Secure "My Bookings" - always uses logged-in user's ID
        [HttpGet("my")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetMyBookings()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized("User ID not found in token.");

            int userId = int.Parse(userIdClaim.Value);
            var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);
            return Ok(bookings);
        }
    }
}