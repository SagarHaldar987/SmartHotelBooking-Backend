using SmartHotelBooking.Models;

namespace SmartHotelBooking.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetByIdAsync(int paymentId);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId);
        Task AddAsync(Payment payment);
        void Update(Payment payment);
        void Delete(Payment payment);
        Task SaveChangesAsync();
    }
}
