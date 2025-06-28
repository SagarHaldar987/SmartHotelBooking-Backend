using System;
using System.Collections.Generic;

namespace SmartHotelBooking.Models;

public partial class Room
{
    public int RoomId { get; set; }
    public int? HotelId { get; set; }
    public int? ManagerId { get; set; } // ✅ NEW

    public string? Type { get; set; }
    public decimal? Price { get; set; }
    public bool? Availability { get; set; } = true;
    public string? Features { get; set; }

    public virtual Hotel? Hotel { get; set; }
    public virtual User? Manager { get; set; } // ✅ NEW
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

