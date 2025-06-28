using System;
using System.Collections.Generic;

namespace SmartHotelBooking.Models;

public partial class Redemption
{
    public int RedemptionId { get; set; }

    public int? UserId { get; set; }

    public int? BookingId { get; set; }

    public int? PointsUsed { get; set; }

    public decimal? DiscountAmount { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual User? User { get; set; }
}
