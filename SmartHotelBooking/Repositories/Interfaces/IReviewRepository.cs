using SmartHotelBooking.Models;

namespace SmartHotelBooking.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> GetByIdAsync(int reviewId);
        Task<IEnumerable<Review>> GetAllAsync();
        Task<IEnumerable<Review>> GetReviewsByHotelIdAsync(int hotelId);
        Task AddAsync(Review review);
        void Update(Review review);
        void Delete(Review review);
        Task SaveChangesAsync();
    }
}
