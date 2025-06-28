using System;
using System.Collections.Generic;

namespace SmartHotelBooking.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? UserId { get; set; }

    public int? RoomId { get; set; }

    public DateOnly? CheckInDate { get; set; }

    public DateOnly? CheckOutDate { get; set; }

    public string? Status { get; set; }

    public int? HotelID { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Redemption> Redemptions { get; set; } = new List<Redemption>();

    public virtual Room? Room { get; set; }

    public virtual User? User { get; set; }
}
