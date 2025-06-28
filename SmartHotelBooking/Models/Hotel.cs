using System;
using System.Collections.Generic;

namespace SmartHotelBooking.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public int? ManagerId { get; set; }

    public string? Amenities { get; set; }

    public decimal? Rating { get; set; }

    public virtual User? Manager { get; set; }

    public string? ImageUrl { get; set; }



    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
