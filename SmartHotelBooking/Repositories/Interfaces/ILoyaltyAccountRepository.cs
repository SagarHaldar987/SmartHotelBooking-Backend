using SmartHotelBooking.Models;

namespace SmartHotelBooking.Repositories.Interfaces
{
    public interface ILoyaltyAccountRepository
    {
        Task<LoyaltyAccount> GetByIdAsync(int loyaltyId);
        Task<LoyaltyAccount> GetByUserIdAsync(int userId);
        //Task<LoyaltyAccount> GetByIdAsync(int loyaltyId);
        Task<IEnumerable<LoyaltyAccount>> GetAllAsync();
        Task AddAsync(LoyaltyAccount account);
        void Update(LoyaltyAccount account);
        void Delete(LoyaltyAccount account);
        Task SaveChangesAsync();
    }
}
