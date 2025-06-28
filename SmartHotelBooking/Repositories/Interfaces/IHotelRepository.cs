using SmartHotelBooking.Models;

namespace SmartHotelBooking.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        Task<Hotel> GetByIdAsync(int hotelId);
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task AddAsync(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(Hotel hotel);
        Task SaveChangesAsync();
    }
}
