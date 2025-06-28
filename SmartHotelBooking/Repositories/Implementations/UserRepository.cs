using Microsoft.EntityFrameworkCore;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;

namespace SmartHotelBooking.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelBookingContext _context;

        public UserRepository(HotelBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _context.Users.ToListAsync();

        public async Task<User> GetByIdAsync(int id)
            => await _context.Users.FindAsync(id);

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

}
