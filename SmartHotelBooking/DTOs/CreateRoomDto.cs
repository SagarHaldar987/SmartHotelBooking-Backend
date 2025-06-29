namespace SmartHotelBooking.DTOs
{
    public class CreateRoomDto
    {
        //public int RoomID { get; set; }
        public int HotelID { get; set; }
        public int ManagerID { get; set; } // ✅ Add this
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public string? Features { get; set; }
    }
}