using System;
using System.Collections.Generic;

namespace SmartHotelBooking.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? UserId { get; set; }

    public int? HotelId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual User? User { get; set; }
}
