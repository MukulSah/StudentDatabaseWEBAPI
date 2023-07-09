using System;
using System.Collections.Generic;

namespace StudentDatabaseWEBAPI.Models;

public partial class DistrictMaster
{
    public int DistrictId { get; set; }

    public string? DistrictName { get; set; }

    public int? IsActive { get; set; }

    public int? StateId { get; set; }
}
