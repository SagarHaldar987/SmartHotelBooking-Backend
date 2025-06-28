using SmartHotelBooking.Models;

namespace SmartHotelBooking.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetByIdAsync(int bookingId);
        //a
        Task<Room> GetRoomByIdAsync(int roomId);
        //a
        //a
        Task<IEnumerable<Booking>> GetBookingsByRoomIdAsync(int roomId);
        void UpdateRoom(Room room);
        //a
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
        Task AddAsync(Booking booking);
        void Update(Booking booking);
        void Delete(Booking booking);
        Task SaveChangesAsync();
    }
}
