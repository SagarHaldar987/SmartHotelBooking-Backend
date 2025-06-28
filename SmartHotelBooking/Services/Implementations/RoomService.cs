using AutoMapper;
using SmartHotelBooking.DTOs;
using SmartHotelBooking.Models;
using SmartHotelBooking.Repositories.Interfaces;
using SmartHotelBooking.Services.Interfaces;

namespace SmartHotelBooking.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<RoomDTO> GetRoomByIdAsync(int roomId)
        {
            var room = await _roomRepository.GetByIdAsync(roomId);
            return _mapper.Map<RoomDTO>(room);
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomDTO>>(rooms);
        }

        public async Task<IEnumerable<RoomDTO>> GetRoomsByHotelIdAsync(int hotelId)
        {
            var rooms = await _roomRepository.GetRoomsByHotelIdAsync(hotelId);
            return _mapper.Map<IEnumerable<RoomDTO>>(rooms);
        }

        public async Task<RoomDTO> CreateRoomAsync(CreateRoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            await _roomRepository.AddAsync(room);
            await _roomRepository.SaveChangesAsync();
            return _mapper.Map<RoomDTO>(room);
        }

        public async Task<bool> UpdateRoomAsync(int roomId, UpdateRoomDto roomDto)
        {
            var existingRoom = await _roomRepository.GetByIdAsync(roomId);
            if (existingRoom == null) return false;

            _mapper.Map(roomDto, existingRoom);
            _roomRepository.Update(existingRoom);
            await _roomRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRoomAsync(int roomId)
        {
            var room = await _roomRepository.GetByIdAsync(roomId);
            if (room == null) return false;

            _roomRepository.Delete(room);
            await _roomRepository.SaveChangesAsync();
            return true;
        }
    }
}
