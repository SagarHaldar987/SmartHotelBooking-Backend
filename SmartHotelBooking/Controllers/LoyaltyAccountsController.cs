using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyAccountsController : ControllerBase
    {
        private readonly ILoyaltyAccountService _loyaltyAccountService;

        public LoyaltyAccountsController(ILoyaltyAccountService loyaltyAccountService)
        {
            _loyaltyAccountService = loyaltyAccountService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> Get(int id) => Ok(await _loyaltyAccountService.GetByIdAsync(id));

        [HttpGet("user/{userId}")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetByUserId(int userId) => Ok(await _loyaltyAccountService.GetByUserIdAsync(userId));

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create(CreateLoyaltyAccountDto dto) => Ok(await _loyaltyAccountService.CreateAsync(dto));

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update(int id, UpdateLoyaltyAccountDto dto) => Ok(await _loyaltyAccountService.UpdateAsync(id, dto));

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int id) => Ok(await _loyaltyAccountService.DeleteAsync(id));
    }

}

