using Microsoft.EntityFrameworkCore;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;

namespace SmartHotelBooking.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly HotelBookingContext _context;

        public PaymentRepository(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<Payment> GetByIdAsync(int paymentId) =>
            await _context.Payments.FindAsync(paymentId);

        public async Task<IEnumerable<Payment>> GetAllAsync() =>
            await _context.Payments.ToListAsync();

        public async Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(int userId) =>
            await _context.Payments.Where(p => p.UserId == userId).ToListAsync();

        public async Task AddAsync(Payment payment) =>
            await _context.Payments.AddAsync(payment);

        public void Update(Payment payment) =>
            _context.Payments.Update(payment);

        public void Delete(Payment payment) =>
            _context.Payments.Remove(payment);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
