using System;
using System.Collections.Generic;

namespace Masterpro_1.Models;

public partial class Update
{
    public int UpdateId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? Date { get; set; }
}
