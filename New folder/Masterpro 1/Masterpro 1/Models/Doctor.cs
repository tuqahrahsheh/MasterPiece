using System;
using System.Collections.Generic;

namespace Masterpro_1.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? Name { get; set; }

    public string? Specialty { get; set; }

    public string? Description { get; set; }

    public string? ContactEmail { get; set; }

    public string? DoctorImage { get; set; }

    public string? RequestStatus { get; set; }
}
