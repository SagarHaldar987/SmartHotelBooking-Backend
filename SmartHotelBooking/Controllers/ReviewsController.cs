using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddReview(CreateReviewDto dto) => Ok(await _reviewService.CreateReviewAsync(dto));

        [HttpGet("hotel/{hotelId}")]
        [Authorize(Roles = "User,Manager")]
        public async Task<IActionResult> GetReviews(int hotelId) => Ok(await _reviewService.GetReviewsByHotelIdAsync(hotelId));
    }

}