using System;
using System.Collections.Generic;

namespace StudentDatabaseWEBAPI.Models;

public partial class StudentDetail
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? EmailId { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public long? MobileNumber { get; set; }

    public DateTime? DateofBirth { get; set; }

    public string? ProfilePicture { get; set; }
}
