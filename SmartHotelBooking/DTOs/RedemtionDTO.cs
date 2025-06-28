namespace SmartHotelBooking.DTOs
{
    public class RedemtionDTO
    {
        public int RedemptionID { get; set; }
        public int UserID { get; set; }
        public int BookingID { get; set; }
        public int PointsUsed { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
