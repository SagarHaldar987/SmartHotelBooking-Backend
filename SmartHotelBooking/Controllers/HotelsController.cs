using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowFrontend")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetAll() => Ok(await _hotelService.GetAllHotelsAsync());

        [HttpGet("manager/{managerId}")]
        public async Task<IActionResult> GetHotelsByManager(int managerId)
        {
            var hotels = await _hotelService.GetHotelsByManagerAsync(managerId);
            return Ok(hotels);
        }

        [HttpPost("manager/{managerId}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateHotel(int managerId, [FromForm] CreateHotelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _hotelService.CreateHotelAsync(managerId, dto);
                return Ok(new { Message = "Hotel created successfully", Hotel = created });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
        }



        [HttpPut("{hotelId}/manager/{managerId}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdateHotel(int hotelId, int managerId, UpdateHotelDto dto)
        {
            var result = await _hotelService.UpdateHotelAsync(hotelId, managerId, dto);
            if (!result)
                return NotFound(new { Message = "Hotel not found or unauthorized" });

            return Ok(new { Message = "Hotel updated successfully" });
        }

        [HttpDelete("{hotelId}/manager/{managerId}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteHotel(int hotelId, int managerId)
        {

            var result = await _hotelService.DeleteHotelAsync(hotelId, managerId);
            if (!result)
                return NotFound(new { Message = "Hotel not found or unauthorized" });

            return Ok(new { Message = "Hotel deleted successfully" });
        }
    }
}