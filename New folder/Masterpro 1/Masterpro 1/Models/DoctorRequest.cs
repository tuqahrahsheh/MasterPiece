using System;
using System.Collections.Generic;

namespace Masterpro_1.Models;

public partial class DoctorRequest
{
    public int RequestId { get; set; }

    public string? Name { get; set; }

    public string? Specialty { get; set; }

    public string? Description { get; set; }

    public string? ContactEmail { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? Status { get; set; }
}
