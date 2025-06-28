using SmartHotelBooking.DTOs;

namespace SmartHotelBooking.Services.Interfaces
{
    public interface IRoomService
    {
        Task<RoomDTO> GetRoomByIdAsync(int roomId);
        Task<IEnumerable<RoomDTO>> GetAllRoomsAsync();
        Task<IEnumerable<RoomDTO>> GetRoomsByHotelIdAsync(int hotelId);
        Task<RoomDTO> CreateRoomAsync(CreateRoomDto roomDto);
        Task<bool> UpdateRoomAsync(int roomId, UpdateRoomDto roomDto);
        Task<bool> DeleteRoomAsync(int roomId);
    }
}
