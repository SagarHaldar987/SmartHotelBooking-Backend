using SmartHotelBooking.DTOs;

namespace SmartHotelBooking.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        //Task<UserDTO> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<bool> UpdateUserAsync(int id, UpdateUserDto dto);
        Task<bool> DeleteUserAsync(int id);
        // Task<UserDTO> CreateUserAsync(CreateUserDto userDto);
        //Task<bool> UpdateUserAsync(int userId, UpdateUserDto userDto);
        //Task<bool> DeleteUserAsync(int userId);
    }
}

