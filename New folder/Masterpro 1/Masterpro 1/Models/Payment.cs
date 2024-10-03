﻿using System;
using System.Collections.Generic;

namespace Masterpro_1.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? UserId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? Status { get; set; }

    public virtual User? User { get; set; }
}
