using System;
using System.Collections.Generic;

namespace FurqanMehdi.Models;

public partial class StdentDatum
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Program { get; set; }

    public string? PhoneNo { get; set; }
}
