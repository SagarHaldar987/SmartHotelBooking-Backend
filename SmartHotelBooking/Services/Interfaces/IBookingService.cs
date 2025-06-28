using SmartHotelBooking.DTOs;

namespace SmartHotelBooking.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDTO> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        Task<IEnumerable<BookingDTO>> GetBookingsByUserIdAsync(int userId);
        Task<BookingDTO> CreateBookingAsync(CreateBookingDto bookingDto,int userId);
        Task<bool> UpdateBookingAsync(int bookingId, UpdateBookingDto bookingDto);
        Task<bool> DeleteBookingAsync(int bookingId);
    }
}
