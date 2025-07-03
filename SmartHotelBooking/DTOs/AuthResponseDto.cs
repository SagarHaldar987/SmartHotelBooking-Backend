namespace SmartHotelBooking.DTOs
{
    public class AuthResponseDto
    {
        //public int UserId { get; set; }
        public string? Message { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
        public int UserId { get; set; } // ✅ Add this line
    }
}