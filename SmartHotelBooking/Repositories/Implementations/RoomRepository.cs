using Microsoft.EntityFrameworkCore;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;

namespace SmartHotelBooking.Repositories.Implementations
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelBookingContext _context;

        public RoomRepository(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<Room> GetByIdAsync(int roomId) =>
            await _context.Rooms.FindAsync(roomId);

        public async Task<IEnumerable<Room>> GetAllAsync() =>
            await _context.Rooms.ToListAsync();

        public async Task<IEnumerable<Room>> GetRoomsByHotelIdAsync(int hotelId) =>
            await _context.Rooms.Where(r => r.HotelId == hotelId).ToListAsync();

        public async Task AddAsync(Room room) =>
            await _context.Rooms.AddAsync(room);

        public void Update(Room room) =>
            _context.Rooms.Update(room);

        public void Delete(Room room) =>
            _context.Rooms.Remove(room);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
