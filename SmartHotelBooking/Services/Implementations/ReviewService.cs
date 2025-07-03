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


            if (review == null) return null;

            return new ReviewDTO


            {


                ReviewID = review.ReviewId,


                UserID = review.UserId ?? 0,


                HotelID = review.HotelId ?? 0,


                Rating = review.Rating ?? 0,


                Comment = review.Comment,


                Timestamp = review.Timestamp ?? DateTime.MinValue,


                UserName = review.User?.Name


            };


        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync()


        {


            var reviews = await _reviewRepository.GetAllAsync();


            return reviews.Select(r => new ReviewDTO


            {


                ReviewID = r.ReviewId,


                UserID = r.UserId ?? 0,


                HotelID = r.HotelId ?? 0,


                Rating = r.Rating ?? 0,


                Comment = r.Comment,


                Timestamp = r.Timestamp ?? DateTime.MinValue,


                UserName = r.User?.Name


            });


        }

        public async Task<IEnumerable<ReviewDTO>> GetReviewsByHotelIdAsync(int hotelId)


        {


            var reviews = await _reviewRepository.GetReviewsByHotelIdAsync(hotelId);


            return reviews.Select(r => new ReviewDTO


            {


                ReviewID = r.ReviewId,


                UserID = r.UserId ?? 0,


                HotelID = r.HotelId ?? 0,


                Rating = r.Rating ?? 0,


                Comment = r.Comment,


                Timestamp = r.Timestamp ?? DateTime.MinValue,


                UserName = r.User?.Name


            });


        }

        public async Task<ReviewDTO> CreateReviewAsync(CreateReviewDto reviewDto)


        {


            var review = _mapper.Map<Review>(reviewDto);


            await _reviewRepository.AddAsync(review);


            await _reviewRepository.SaveChangesAsync();

            var savedReview = await _reviewRepository.GetByIdAsync(review.ReviewId);

            return new ReviewDTO


            {


                ReviewID = savedReview.ReviewId,


                UserID = savedReview.UserId ?? 0,


                HotelID = savedReview.HotelId ?? 0,


                Rating = savedReview.Rating ?? 0,


                Comment = savedReview.Comment,


                Timestamp = savedReview.Timestamp ?? DateTime.MinValue,


                UserName = savedReview.User?.Name


            };


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

