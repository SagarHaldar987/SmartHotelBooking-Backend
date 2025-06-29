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

        // ✅ Add these methods for new logic
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task<Room> GetRoomByIdAsync(int roomId);
        void UpdateRoom(Room room);
        void UpdateBooking(Booking booking);
    }
}
