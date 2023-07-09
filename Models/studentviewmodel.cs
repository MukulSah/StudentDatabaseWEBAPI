namespace StudentDatabaseWEBAPI.Models
{
    internal class studentviewmodel
    {
        public studentviewmodel()
        {
        }

        public int StudentId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailId { get; set; }

        public long? MobileNumber { get; set; }

        public string? FatherName { get; set; }

        public string? MotherName { get; set; }

        public DateTime? DateofBirth { get; set; }

        public string? ProfilePicture { get; set; }

        public int CAddressId { get; set; }
        public int? CAddressType { get; set; }
        public string? CorrespondanceAddressLine1 { get; set; }

        public string? CorrespondanceAddressLine2 { get; set; }

        public string? CCity { get; set; }

        public int? CCountryId { get; set; }

        public string? CCountryName { get; set; }

        public int? CStateId { get; set; }

        public string? CStateName { get; set; }

        public int? CDistrictId { get; set; }

        public string? CDistrictName { get; set; }

        public int? CPincode { get; set; }
        public int PAddressId { get; set; }
        public int? PAddressType { get; set; }
        public string? PermanentAddressLine1 { get; set; }
        public string? PermanentAddressLine2 { get; set; }
        public string? PCity { get; set; }
        public int? PCountryId { get; set; }
        public string? PCountryName { get; set; }
        public int? PStateId { get; set; }
        public string? PStateName { get; set; }
        public int? PDistrictId { get; set; }
        public string? PDistrictName { get; set; }
        public int? PPincode { get; set; }
    }
}
