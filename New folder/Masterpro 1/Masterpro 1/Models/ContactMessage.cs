using System;
using System.Collections.Generic;

namespace Masterpro_1.Models;

public partial class ContactMessage
{
    public int MessageId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public DateTime? DateSent { get; set; }
}
