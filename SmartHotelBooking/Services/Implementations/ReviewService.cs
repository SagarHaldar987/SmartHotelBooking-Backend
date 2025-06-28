using AutoMapper;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDTO> GetReviewByIdAsync(int reviewId)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewId);
            return _mapper.Map<ReviewDTO>(review);
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<IEnumerable<ReviewDTO>> GetReviewsByHotelIdAsync(int hotelId)
        {
            var reviews = await _reviewRepository.GetReviewsByHotelIdAsync(hotelId);
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<ReviewDTO> CreateReviewAsync(CreateReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveChangesAsync();
            return _mapper.Map<ReviewDTO>(review);
        }

        public async Task<bool> UpdateReviewAsync(int reviewId, UpdateReviewDto reviewDto)
        {
            var existingReview = await _reviewRepository.GetByIdAsync(reviewId);
            if (existingReview == null) return false;

            _mapper.Map(reviewDto, existingReview);
            _reviewRepository.Update(existingReview);
            await _reviewRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewId);
            if (review == null) return false;

            _reviewRepository.Delete(review);
            await _reviewRepository.SaveChangesAsync();
            return true;
        }
    }
}
