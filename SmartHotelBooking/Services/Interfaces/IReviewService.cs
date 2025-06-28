using SmartHotelBooking.DTOs;

namespace SmartHotelBooking.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDTO> GetReviewByIdAsync(int reviewId);
        Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync();
        Task<IEnumerable<ReviewDTO>> GetReviewsByHotelIdAsync(int hotelId);
        Task<ReviewDTO> CreateReviewAsync(CreateReviewDto reviewDto);
        Task<bool> UpdateReviewAsync(int reviewId, UpdateReviewDto reviewDto);
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}
