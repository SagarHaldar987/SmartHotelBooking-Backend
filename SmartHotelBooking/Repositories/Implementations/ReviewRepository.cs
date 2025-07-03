using Microsoft.EntityFrameworkCore;


using SmartHotelBooking.Models;


using SmartHotelBooking.Repositories.Interfaces;

namespace SmartHotelBooking.Repositories.Implementations


{


    public class ReviewRepository : IReviewRepository


    {


        private readonly HotelBookingContext _context;

        public ReviewRepository(HotelBookingContext context)


        {


            _context = context;


        }

        public async Task<Review> GetByIdAsync(int reviewId) =>


            await _context.Reviews


                .Include(r => r.User)


                .FirstOrDefaultAsync(r => r.ReviewId == reviewId);

        public async Task<IEnumerable<Review>> GetAllAsync() =>


            await _context.Reviews


                .Include(r => r.User)


                .ToListAsync();

        public async Task<IEnumerable<Review>> GetReviewsByHotelIdAsync(int hotelId) =>


            await _context.Reviews


                .Where(r => r.HotelId == hotelId)


                .Include(r => r.User)


                .ToListAsync();

        public async Task AddAsync(Review review) =>


            await _context.Reviews.AddAsync(review);

        public void Update(Review review) => _context.Reviews.Update(review);

        public void Delete(Review review) => _context.Reviews.Remove(review);

        public async Task SaveChangesAsync() =>


            await _context.SaveChangesAsync();


    }


}

