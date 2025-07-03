//namespace SmartHotelBooking.DTOs
//{
//    public class ReviewDTO
//    {
//        public int ReviewID { get; set; }
//        public int UserID { get; set; }
//        public int HotelID { get; set; }
//        public int Rating { get; set; }
//        public string? Comment { get; set; }
//        public DateTime Timestamp { get; set; }
//    }
//}


namespace SmartHotelBooking.DTOs
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int HotelID { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Timestamp { get; set; }

        // ✅ Add this line
        public string? UserName { get; set; }
    }
}