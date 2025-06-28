using SmartHotelBooking.DTOs;

namespace SmartHotelBooking.Services.Interfaces
{
    public interface ILoyaltyAccountService
    {
        Task<LoyaltyAccountDTO> GetByIdAsync(int loyaltyId);
        Task<LoyaltyAccountDTO> GetByUserIdAsync(int userId);
        Task<LoyaltyAccountDTO> CreateAsync(CreateLoyaltyAccountDto accountDto);
        Task<bool> UpdateAsync(int loyaltyId, UpdateLoyaltyAccountDto accountDto);
        Task<bool> DeleteAsync(int loyaltyId);
    }
}
