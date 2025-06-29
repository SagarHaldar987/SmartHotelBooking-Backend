using AutoMapper;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomService _roomService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository,
                           IRoomService roomService, IPaymentRepository paymentRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _roomService = roomService;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<BookingDTO> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            return _mapper.Map<BookingDTO>(booking);
        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
        }

        public async Task<IEnumerable<BookingDTO>> GetBookingsByUserIdAsync(int userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
        }


        public async Task<BookingDTO> CreateBookingAsync(CreateBookingDto bookingDto, int userId)

        {

            var room = await _bookingRepository.GetRoomByIdAsync(bookingDto.RoomID);

            if (room == null)

                throw new Exception("Room not found.");

            // Check for overlapping bookings

            var existingBookings = await _bookingRepository.GetBookingsByRoomIdAsync(bookingDto.RoomID);

            bool isOverlapping = existingBookings.Any(b =>

                b.CheckInDate <= DateOnly.FromDateTime(bookingDto.CheckOutDate) &&

                b.CheckOutDate >= DateOnly.FromDateTime(bookingDto.CheckInDate));

            if (isOverlapping)

                throw new Exception("Room is already booked for the selected dates.");

            var booking = _mapper.Map<Booking>(bookingDto);

            booking.UserId = userId;

            booking.HotelID = room.HotelId;

            // Mark room as unavailable

            //room.Availability = false;

            await _bookingRepository.AddAsync(booking);

            //_bookingRepository.UpdateRoom(room); // Add this method to repository

            await _bookingRepository.SaveChangesAsync();

            return _mapper.Map<BookingDTO>(booking);

        }



        //✅ New Method to Check Room Availability
        private async Task<bool> IsRoomAvailableAsync(int roomId, DateTime checkIn, DateTime checkOut)
        {
            DateOnly checkInDateOnly = DateOnly.FromDateTime(checkIn);
            DateOnly checkOutDateOnly = DateOnly.FromDateTime(checkOut);

            var conflictingBookings = await _bookingRepository.GetAllAsync();

            return !conflictingBookings.Any(b =>
                b.RoomId == roomId &&
                b.CheckInDate.HasValue && b.CheckOutDate.HasValue && // ✅ Ensure dates are not null
                ((checkInDateOnly >= b.CheckInDate.Value && checkInDateOnly < b.CheckOutDate.Value) ||  // Check-in conflicts
                 (checkOutDateOnly > b.CheckInDate.Value && checkOutDateOnly <= b.CheckOutDate.Value) || // Check-out conflicts
                 (checkInDateOnly <= b.CheckInDate.Value && checkOutDateOnly >= b.CheckOutDate.Value))); // Enclosing date conflicts
        }


        public async Task<bool> UpdateBookingAsync(int bookingId, UpdateBookingDto bookingDto)
        {
            var existingBooking = await _bookingRepository.GetByIdAsync(bookingId);
            if (existingBooking == null) return false;

            _mapper.Map(bookingDto, existingBooking);
            _bookingRepository.Update(existingBooking);
            await _bookingRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null) return false;

            _bookingRepository.Delete(booking);
            await _bookingRepository.SaveChangesAsync();
            return true;
        }
    }
}
