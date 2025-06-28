using SmartHotelBooking.DTOs;

namespace SmartHotelBooking.Services.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelDTO>> GetAllHotelsAsync();
        Task<HotelDTO?> GetHotelByIdAsync(int hotelId);
        Task<List<HotelDTO>> GetHotelsByManagerAsync(int managerId);
        Task<HotelDTO> CreateHotelAsync(int managerId, CreateHotelDto dto);
        Task<bool> UpdateHotelAsync(int hotelId, int managerId, UpdateHotelDto dto);
        Task<bool> DeleteHotelAsync(int hotelId, int managerId);
    }
}
