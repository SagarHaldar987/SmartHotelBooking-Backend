namespace SmartHotelBooking.DTOs
{
    public class UpdateLoyaltyAccountDto
    {
       // public int LoyaltyID { get; set; }
        public int UserID { get; set; }
        public int PointsBalance { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}