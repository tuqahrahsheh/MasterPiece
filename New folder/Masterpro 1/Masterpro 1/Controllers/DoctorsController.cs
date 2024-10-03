using Masterpro_1.DTOs;
using Masterpro_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace Masterpro_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly MyDbContext _db;
        private readonly string _uploadFolderPath;

        public DoctorsController(MyDbContext db)
        {
            _db = db;
            _uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");  
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {

            var doctors = _db.Doctors.Select(d => new DoctorResponseDTO
            {
                Name = d.Name,
                Specialty = d.Specialty,
                Description = d.Description,
                ContactEmail = d.ContactEmail,
                DoctorImage = d.DoctorImage
            }).ToList();

            return Ok(doctors);
        }

        [HttpPost]
        public IActionResult AddDoctor([FromForm] DoctorRequestDTO dTO)
        {
            if (dTO.DoctorImage != null)
            {
                // Ensure the upload folder exists
                if (!Directory.Exists(_uploadFolderPath))
                {
                    Directory.CreateDirectory(_uploadFolderPath);
                }

                // Save the uploaded image to the server
                var fileName = Path.GetFileName(dTO.DoctorImage.FileName);
                var filePath = Path.Combine(_uploadFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    dTO.DoctorImage.CopyTo(stream);
                }

                // Save doctor details to the database
                var doctor = new Doctor
                {
                    Name = dTO.Name,
                    Specialty = dTO.Specialty,
                    Description = dTO.Description,
                    ContactEmail = dTO.ContactEmail,
                    DoctorImage = fileName  // Save the file name to the database
                };

                _db.Doctors.Add(doctor);
                _db.SaveChanges();

                return Ok(new { Message = "Doctor added successfully", Doctor = doctor });
            }
            else
            {
                return BadRequest("Doctor image is required.");
            }
        }
    }
}
