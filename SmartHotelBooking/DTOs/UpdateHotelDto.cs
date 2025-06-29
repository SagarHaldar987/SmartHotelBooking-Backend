namespace SmartHotelBooking.DTOs
{
    public class UpdateHotelDto
    {
        //public int HotelID { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int ManagerID { get; set; }
        public string? Amenities { get; set; }
        public decimal Rating { get; set; }
    }
}