using SmartHotelBooking.Models;

namespace SmartHotelBooking.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetByIdAsync(int roomId);
        Task<IEnumerable<Room>> GetAllAsync();
        Task<IEnumerable<Room>> GetRoomsByHotelIdAsync(int hotelId);
        Task AddAsync(Room room);
        void Update(Room room);
        void Delete(Room room);
        Task SaveChangesAsync();
    }
}
