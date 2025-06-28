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
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("hotel/{hotelId}")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetRoomsByHotel(int hotelId) => Ok(await _roomService.GetRoomsByHotelIdAsync(hotelId));

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create(CreateRoomDto dto) => Ok(await _roomService.CreateRoomAsync(dto));

        [HttpPut("{roomId}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update(int roomId, UpdateRoomDto dto) => Ok(await _roomService.UpdateRoomAsync(roomId, dto));

        [HttpDelete("{roomId}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int roomId) => Ok(await _roomService.DeleteRoomAsync(roomId));


        [HttpGet("{roomId}")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetRoomById(int roomId)
        {
            var room = await _roomService.GetRoomByIdAsync(roomId);
            if (room == null)
                return NotFound();
            return Ok(room);
        }
    }
}