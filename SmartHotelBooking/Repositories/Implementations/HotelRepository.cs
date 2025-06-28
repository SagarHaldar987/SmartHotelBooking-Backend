using Microsoft.EntityFrameworkCore;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;

namespace SmartHotelBooking.Repositories.Implementations
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelBookingContext _context;

        public HotelRepository(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<Hotel> GetByIdAsync(int hotelId) =>
            await _context.Hotels.FindAsync(hotelId);

        public async Task<IEnumerable<Hotel>> GetAllAsync() =>
            await _context.Hotels.ToListAsync();

        public async Task AddAsync(Hotel hotel) =>
            await _context.Hotels.AddAsync(hotel);

        public void Update(Hotel hotel) =>
            _context.Hotels.Update(hotel);

        public void Delete(Hotel hotel) =>
            _context.Hotels.Remove(hotel);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
