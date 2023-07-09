using System;
using System.Collections.Generic;

namespace StudentDatabaseWEBAPI.Models;

public partial class StateMaster
{
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public int? IsActive { get; set; }

    public int? CountryId { get; set; }
}
