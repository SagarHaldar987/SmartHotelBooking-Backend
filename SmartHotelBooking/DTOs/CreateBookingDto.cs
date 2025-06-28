namespace SmartHotelBooking.DTOs
{
    public class CreateBookingDto
    {
        //public int BookingID { get; set; }
        //public int UserID { get; set; }
        public int RoomID { get; set; }
        //public int HotelID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
        
        //public int? PaymentID { get; set; }
    }
}