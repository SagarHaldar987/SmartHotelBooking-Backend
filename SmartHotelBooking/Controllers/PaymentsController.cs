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
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Authorize(Roles = "Manager,User,Admin")]
        public async Task<IActionResult> MakePayment(CreatePaymentDto dto) => Ok(await _paymentService.CreatePaymentAsync(dto));
    }

}