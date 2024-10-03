using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Masterpro_1.Models;

public partial class MedicalSuppliesRequest
{
    public int RequestId { get; set; }
    [Required]

    public string UserName { get; set; } = null!;
    [Required]

    public string Address { get; set; } = null!;
    [Required]

    public string MedicationName { get; set; } = null!;
    [Required]

    public DateTime DeliveryTime { get; set; }

    public string? PrescriptionFilePath { get; set; }
}
