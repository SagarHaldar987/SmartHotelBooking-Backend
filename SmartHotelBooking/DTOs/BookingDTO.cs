namespace SmartHotelBooking.DTOs
{
    public class BookingDTO
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public string? Status { get; set; }
        
    }
}
