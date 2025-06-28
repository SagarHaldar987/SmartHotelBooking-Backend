namespace SmartHotelBooking.DTOs
{
    public class RoomDTO
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public int ManagerID { get; set; } // ✅ Add if you want to expose in response
        public string Type { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public string Features { get; set; }
    }
}
