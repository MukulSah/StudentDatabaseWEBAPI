namespace StudentDatabaseWEBAPI.Models
{
    public class studentcarriedinfo
    {
        public StudentDetail Obj1 { get; set; }

        public CorrespondanceAddress Obj2 { get; set; }
        public PermanentAddress Obj3 { get; set; }
    }

    public class StudentDetails
    {
        public int StuId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailId { get; set; }

        public long? MobileNumber { get; set; }

        public string? FatherName { get; set; }

        public string? MotherName { get; set; }

        public DateTime? DateofBirth { get; set; }

        public string? ProfilePicture { get; set; }
    }


    public partial class CorrespondanceAddress
    {

        public int StuId { get; set; }
        public int AddressId { get; set; }
        public int? AddressType { get; set; }
        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public int? CountryId { get; set; }

        public int? StateId { get; set; }

        public int? DistrictId { get; set; }

        public int? Pincode { get; set; }

    }



    public partial class PermanentAddress

    {
        public int StuId { get; set; }
        public int AddressId { get; set; }
        public int? AddressType { get; set; }
        public string? PAddressLine1 { get; set; }
        public string? PAddressLine2 { get; set; }

        public string? PCity { get; set; }

        public int? PCountryId { get; set; }

        public int? PStateId { get; set; }

        public int? PDistrictId { get; set; }

        public int? PPincode { get; set; }
    }
}
