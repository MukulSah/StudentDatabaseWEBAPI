using System;
using System.Collections.Generic;

namespace StudentDatabaseWEBAPI.Models;

public partial class CountryMaster
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public int? IsActive { get; set; }
}
