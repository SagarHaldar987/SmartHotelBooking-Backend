using AutoMapper;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Services.Implementations
{
    public class LoyaltyAccountService : ILoyaltyAccountService
    {
        private readonly ILoyaltyAccountRepository _repository;
        private readonly IMapper _mapper;

        public LoyaltyAccountService(ILoyaltyAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LoyaltyAccountDTO> GetByIdAsync(int loyaltyId)
        {
            var entity = await _repository.GetByIdAsync(loyaltyId);
            return _mapper.Map<LoyaltyAccountDTO>(entity);
        }

        public async Task<LoyaltyAccountDTO> GetByUserIdAsync(int userId)
        {
            var entity = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<LoyaltyAccountDTO>(entity);
        }

        public async Task<LoyaltyAccountDTO> CreateAsync(CreateLoyaltyAccountDto accountDto)
        {
            var entity = _mapper.Map<LoyaltyAccount>(accountDto);
            entity.LastUpdated = DateTime.UtcNow;

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<LoyaltyAccountDTO>(entity);
        }

        public async Task<bool> UpdateAsync(int loyaltyId, UpdateLoyaltyAccountDto accountDto)
        {
            var entity = await _repository.GetByIdAsync(loyaltyId);
            if (entity == null)
                return false;

            _mapper.Map(accountDto, entity);
            entity.LastUpdated = DateTime.UtcNow;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int loyaltyId)
        {
            var entity = await _repository.GetByIdAsync(loyaltyId);
            if (entity == null)
                return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}