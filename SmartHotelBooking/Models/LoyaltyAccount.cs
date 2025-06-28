using System;
using System.Collections.Generic;

namespace SmartHotelBooking.Models;

public partial class LoyaltyAccount
{
    public int LoyaltyId { get; set; }

    public int? UserId { get; set; }

    public int? PointsBalance { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual User? User { get; set; }
}
