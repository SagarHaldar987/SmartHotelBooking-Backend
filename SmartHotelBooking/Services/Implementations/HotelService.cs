using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Models;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Services.Implementations
{
    public class HotelService : IHotelService
    {
        private readonly HotelBookingContext _context;
        private readonly IMapper _mapper;
        

        public HotelService(HotelBookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        public async Task<IEnumerable<HotelDTO>> GetAllHotelsAsync()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return _mapper.Map<IEnumerable<HotelDTO>>(hotels);
        }

        public async Task<HotelDTO> GetHotelByIdAsync(int hotelId)
        {
            var hotel = await _context.Hotels.FindAsync(hotelId);
            return _mapper.Map<HotelDTO>(hotel);
        }

        public async Task<List<HotelDTO>> GetHotelsByManagerAsync(int managerId)
        {
            var hotels = await _context.Hotels
                .Where(h => h.ManagerId == managerId)
                .ToListAsync();

            return _mapper.Map<List<HotelDTO>>(hotels);
        }

        public async Task<HotelDTO> CreateHotelAsync(int managerId, CreateHotelDto hoteldto)
        {
            var existingHotel = await _context.Hotels.ToListAsync();

            if (existingHotel.Any(h => h.Name == hoteldto.Name && h.Location == hoteldto.Location && h.ManagerId == managerId))
                throw new InvalidOperationException("Hotel already exists for this manager.");

            var hotel = _mapper.Map<Hotel>(hoteldto);
            hotel.ManagerId = managerId;

            // ✅ Save image
            if (hoteldto.Image != null && hoteldto.Image.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/hotels");
                Directory.CreateDirectory(uploadsFolder); // Ensure folder exists

                var fileName = $"{Guid.NewGuid()}_{hoteldto.Image.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await hoteldto.Image.CopyToAsync(stream);
                }

                hotel.ImageUrl = $"/images/hotels/{fileName}";
            }

            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();

            return _mapper.Map<HotelDTO>(hotel);
        }



        public async Task<bool> UpdateHotelAsync(int hotelId, int managerId, UpdateHotelDto dto)
        {

            // Check if manager exists
            var managerExists = await _context.Users.AnyAsync(u => u.UserId == managerId);
            if (!managerExists)
                return false;


            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(h => h.HotelId == hotelId && h.ManagerId == managerId);

            if (hotel == null)
                return false;

            _mapper.Map(dto, hotel);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                // Log or handle exception
                return false;
            }

        }

        public async Task<bool> DeleteHotelAsync(int hotelId, int managerId)
        {
            var hotel = await _context.Hotels
                .Include(h=>h.Rooms)
                .FirstOrDefaultAsync(h => h.HotelId == hotelId && h.ManagerId == managerId);

            if (hotel == null)
                return false;


            if (hotel.Rooms.Any())
                return false; // Or return a custom message like "Hotel has rooms and cannot be deleted."

            _context.Hotels.Remove(hotel);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                // Log or handle exception
                return false;
            }

        }
    }
}