using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using StudentDatabaseWEBAPI.Models;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks.Dataflow;

namespace StudentDatabaseWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDetailReportContext _context;

        public StudentController(StudentDetailReportContext _context)
        {
            this._context = _context;
        }

        [HttpPost]
        [Route("CreateStudentDetail")]
        public async Task<IActionResult> CreateStudentDetail(studentcarriedinfo studentcarriedInfo)
        {

            var details = new StudentDetail()
            {
                FirstName = studentcarriedInfo.Obj1.FirstName,
                LastName = studentcarriedInfo.Obj1.LastName,
                FatherName = studentcarriedInfo.Obj1.FatherName,
                DateofBirth = studentcarriedInfo.Obj1.DateofBirth,
                MotherName = studentcarriedInfo.Obj1.MotherName,
                MobileNumber = studentcarriedInfo.Obj1.MobileNumber,
                EmailId = studentcarriedInfo.Obj1.EmailId,
                ProfilePicture = studentcarriedInfo.Obj1.ProfilePicture
            };
            await _context.StudentDetails.AddAsync(details);
            await _context.SaveChangesAsync();



            var caddressdetails = new AddressTable()
            {
                AddressId = studentcarriedInfo.Obj2.AddressId,
                StudentId = details.StudentId,
                AddressType = 1,
                AddressLine1 = studentcarriedInfo.Obj2.AddressLine1,
                AddressLine2 = studentcarriedInfo.Obj2.AddressLine2,
                City = studentcarriedInfo.Obj2.City,
                CountryId = studentcarriedInfo.Obj2.CountryId,
                StateId = studentcarriedInfo.Obj2.StateId,
                DistrictId = studentcarriedInfo.Obj2.DistrictId,
                Pincode = studentcarriedInfo.Obj2.Pincode

            };
            await _context.AddressTables.AddAsync(caddressdetails);
            await _context.SaveChangesAsync();



            var paddressdetails = new AddressTable()
            {
                AddressId = studentcarriedInfo.Obj3.AddressId,
                StudentId = details.StudentId,
                AddressType = 2,
                AddressLine1 = studentcarriedInfo.Obj3.PAddressLine1,
                AddressLine2 = studentcarriedInfo.Obj3.PAddressLine2,
                City = studentcarriedInfo.Obj3.PCity,
                CountryId = studentcarriedInfo.Obj3.PCountryId,
                StateId = studentcarriedInfo.Obj3.PStateId,
                DistrictId = studentcarriedInfo.Obj3.PDistrictId,
                Pincode = studentcarriedInfo.Obj3.PPincode
            };
            await _context.AddressTables.AddAsync(paddressdetails);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet]
        public IActionResult GetPAddress()
        {
            var query = (from s in _context.StudentDetails
            join adp in _context.AddressTables.Where(adp => adp.AddressType == 2) on s.StudentId equals adp.AddressId
            select new studentviewmodel()
            {
                PAddressId = adp.AddressId,
                PAddressType = adp.AddressType,
                PermanentAddressLine1 = adp.AddressLine1
                }).ToList();

            return Ok(query);
        }


        [HttpGet]
        [Route("GetAllStudentRecord")]
        public IActionResult GetAllStudentRecord()
        {
            var query = (
               from s in _context.StudentDetails
               join ad in _context.AddressTables.Where(ad => ad.AddressType == 1) on s.StudentId equals ad.AddressId
               join cm in _context.CountryMasters on ad.CountryId equals cm.CountryId
               join sm in _context.StateMasters on ad.StateId equals sm.StateId
               join dm in _context.DistrictMasters on ad.DistrictId equals dm.DistrictId
               join pad in _context.AddressTables.Where(adp => adp.AddressType ==2 ) on s.StudentId equals pad.StudentId
               join pcm in _context.CountryMasters on ad.CountryId equals pcm.CountryId
               join psm in _context.StateMasters on ad.StateId equals psm.StateId
               join pdm in _context.DistrictMasters on ad.DistrictId equals pdm.DistrictId

               select new studentviewmodel()
               {
                   StudentId = s.StudentId,
                   FirstName = s.FirstName,
                   LastName = s.LastName,
                   FatherName = s.FatherName,
                   MotherName = s.MotherName,
                   EmailId = s.EmailId,
                   MobileNumber = s.MobileNumber,
                   DateofBirth = s.DateofBirth,
                   ProfilePicture = s.ProfilePicture,
                   CAddressId = ad.AddressId,
                   CAddressType = ad.AddressType,
                   CorrespondanceAddressLine1 = ad.AddressLine1,
                   CorrespondanceAddressLine2 = ad.AddressLine2,
                   CCity = ad.City,
                   CCountryId = cm.CountryId,
                   CCountryName = cm.CountryName,
                   CStateId = sm.StateId,
                   CStateName = sm.StateName,
                   CDistrictId = dm.DistrictId,
                   CDistrictName = dm.DistrictName,
                   CPincode = ad.Pincode,
                   PAddressId = pad.AddressId,
                   PAddressType = pad.AddressType,
                   PermanentAddressLine1 = pad.AddressLine1,
                   PermanentAddressLine2 = pad.AddressLine2,
                   PCity = pad.City,
                   PCountryId = pcm.CountryId,
                   PCountryName = pcm.CountryName,
                   PStateId = psm.StateId,
                   PStateName = psm.StateName,
                   PDistrictId = pdm.DistrictId,
                   PDistrictName = pdm.DistrictName,
                   PPincode = pad.Pincode
               }).ToList();
            return Ok(query);

        }

        [HttpGet]
        [Route("GetStudentDetailbyID {id:int}")]
        public IActionResult GetStudentDetailbyID(int id)
        {
            var query = (from s in _context.StudentDetails.Where(s => s.StudentId == id)
                         join ad in _context.AddressTables.Where(ad => ad.AddressType == 1) on s.StudentId equals ad.AddressId
                         join cm in _context.CountryMasters on ad.CountryId equals cm.CountryId
                         join sm in _context.StateMasters on ad.StateId equals sm.StateId
                         join dm in _context.DistrictMasters on ad.DistrictId equals dm.DistrictId
                         join pad in _context.AddressTables.Where(adp => adp.AddressType == 2) on s.StudentId equals pad.StudentId
                         join pcm in _context.CountryMasters on ad.CountryId equals pcm.CountryId
                         join psm in _context.StateMasters on ad.StateId equals psm.StateId
                         join pdm in _context.DistrictMasters on ad.DistrictId equals pdm.DistrictId
                         select new studentviewmodel()
                         {
                             StudentId = s.StudentId,
                             FirstName = s.FirstName,
                             LastName = s.LastName,
                             FatherName = s.FatherName,
                             MotherName = s.MotherName,
                             EmailId = s.EmailId,
                             MobileNumber = s.MobileNumber,
                             DateofBirth = s.DateofBirth,
                             ProfilePicture = s.ProfilePicture,
                             CAddressId = ad.AddressId,
                             CAddressType = ad.AddressType,
                             CorrespondanceAddressLine1 = ad.AddressLine1,
                             CorrespondanceAddressLine2 = ad.AddressLine2,
                             CCity = ad.City,
                             CCountryId = cm.CountryId,
                             CCountryName = cm.CountryName,
                             CStateId = sm.StateId,
                             CStateName = sm.StateName,
                             CDistrictId = dm.DistrictId,
                             CDistrictName = dm.DistrictName,
                             CPincode = ad.Pincode,
                             PAddressId = pad.AddressId,
                             PAddressType = pad.AddressType,
                             PermanentAddressLine1 = pad.AddressLine1,
                             PermanentAddressLine2 = pad.AddressLine2,
                             PCity = pad.City,
                             PCountryId = pcm.CountryId,
                             PCountryName = pcm.CountryName,
                             PStateId = psm.StateId,
                             PStateName = psm.StateName,
                             PDistrictId = pdm.DistrictId,
                             PDistrictName = pdm.DistrictName,
                             PPincode = pad.Pincode
                         }).ToList();
            return Ok(query);
                
        }


    }
}
