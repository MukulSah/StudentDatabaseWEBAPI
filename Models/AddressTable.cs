using System;
using System.Collections.Generic;

namespace StudentDatabaseWEBAPI.Models;

public partial class AddressTable
{
    public int AddressId { get; set; }

    public int? StudentId { get; set; }

    public int? AddressType { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? DistrictId { get; set; }

    public int? Pincode { get; set; }
}
