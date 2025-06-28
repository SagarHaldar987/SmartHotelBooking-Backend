using Microsoft.EntityFrameworkCore;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;

namespace SmartHotelBooking.Repositories.Implementations
{
    namespace SmartHotelBooking.Repositories
    {
        public class LoyaltyAccountRepository : ILoyaltyAccountRepository
        {
            private readonly HotelBookingContext _context;

            public LoyaltyAccountRepository(HotelBookingContext context)
            {
                _context = context;
            }

            public async Task<LoyaltyAccount> GetByUserIdAsync(int userId)
            {
                return await _context.LoyaltyAccounts
                    .FirstOrDefaultAsync(l => l.UserId == userId);
            }

            public async Task<IEnumerable<LoyaltyAccount>> GetAllAsync()
            {
                return await _context.LoyaltyAccounts.ToListAsync();
            }

            public async Task AddAsync(LoyaltyAccount account)
            {
                await _context.LoyaltyAccounts.AddAsync(account);
            }

            public async Task UpdateAsync(LoyaltyAccount account)
            {
                _context.LoyaltyAccounts.Update(account);
            }

            public async Task SaveChangesAsync()
            {
                await _context.SaveChangesAsync();
            }

            public async Task<LoyaltyAccount> GetByIdAsync(int loyaltyId)
            {
                return await _context.LoyaltyAccounts.FirstOrDefaultAsync(l => l.LoyaltyId == loyaltyId);

            }

            public void Update(LoyaltyAccount account)
            {
                throw new NotImplementedException();
            }

            public void Delete(LoyaltyAccount account)
            {
                throw new NotImplementedException();
            }
        }
    }
}
