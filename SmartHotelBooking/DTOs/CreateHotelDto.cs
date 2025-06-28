using System.ComponentModel.DataAnnotations;

namespace SmartHotelBooking.DTOs
{
    public class CreateHotelDto
    {
        //public int HotelID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int ManagerID { get; set; }

        [Required]
        public string Amenities { get; set; }


        [Range(0, 5)]

        public decimal Rating { get; set; }

        public IFormFile? Image { get; set; } // ✅ For image upload
    }
}