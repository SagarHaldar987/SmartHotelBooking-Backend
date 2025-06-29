using Microsoft.EntityFrameworkCore;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;

namespace SmartHotelBooking.Repositories.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelBookingContext _context;

        public BookingRepository(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<Booking> GetByIdAsync(int bookingId) =>
            await _context.Bookings.FindAsync(bookingId);

        public async Task<IEnumerable<Booking>> GetAllAsync() =>
            await _context.Bookings.ToListAsync();

        //public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId) =>
        //    await _context.Bookings.Where(b => b.UserId == userId).ToListAsync();
        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId) =>
        await _context.Bookings
        .Where(b => b.UserId == userId && b.Status == true)
        .ToListAsync();


        public async Task<IEnumerable<Booking>> GetBookingsByRoomIdAsync(int roomId)

        {

            return await _context.Bookings

                .Where(b => b.RoomId == roomId)

                .ToListAsync();

        }

        public void UpdateRoom(Room room)

        {

            _context.Rooms.Update(room);

        }
        
        public async Task<Room> GetRoomByIdAsync(int roomId)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == roomId);
        }

        public async Task AddAsync(Booking booking) =>
            await _context.Bookings.AddAsync(booking);

        public void Update(Booking booking) =>
            _context.Bookings.Update(booking);

        public void Delete(Booking booking) =>
            _context.Bookings.Remove(booking);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();

    }
}
