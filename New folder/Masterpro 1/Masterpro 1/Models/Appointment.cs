using System;
using System.Collections.Generic;

namespace Masterpro_1.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? UserId { get; set; }

    public int? ServiceId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public string? Message { get; set; }

    public string? Status { get; set; }

    public virtual Service? Service { get; set; }

    public virtual User? User { get; set; }
}
