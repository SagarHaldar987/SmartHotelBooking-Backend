using SmartHotelBooking.DTOs;

namespace SmartHotelBooking.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentDTO> GetPaymentByIdAsync(int paymentId);
        Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync();
        Task<IEnumerable<PaymentDTO>> GetPaymentsByUserIdAsync(int userId);
        Task<PaymentDTO> CreatePaymentAsync(CreatePaymentDto paymentDto);
        Task<bool> UpdatePaymentAsync(int paymentId, UpdatePaymentDto paymentDto);
        Task<bool> DeletePaymentAsync(int paymentId);
    }
}
