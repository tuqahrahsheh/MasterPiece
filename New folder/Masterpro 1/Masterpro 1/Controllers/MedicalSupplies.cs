using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Masterpro_1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Masterpro_1.DTOs;

namespace Masterpro_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalSupplies : ControllerBase
    {
        private readonly MyDbContext _db;
        private readonly IWebHostEnvironment _environment;
        public MedicalSupplies(MyDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        [HttpPost]
        public IActionResult addMedicalSuply([FromForm] MedicalSuppliesRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string filepath = "";
            if (dto.PrescriptionFile != null && dto.PrescriptionFile.Length > 0)
            {
                if (Path.GetExtension(dto.PrescriptionFile.FileName).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.PrescriptionFile.FileName)}";
                    var uploads = Path.Combine(_environment.WebRootPath, "UploadedFiles");
                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }
                    var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);

                    dto.PrescriptionFile.CopyToAsync(fileStream);

                    fileStream.Close();
                    filepath = Path.Combine("UploadedFiles", fileName);

                }
                else
                {
                    ModelState.AddModelError("PrescriptionFile", "Only PDF files are allowed.");
                    return BadRequest(ModelState);

                }

            }
            else
            {
                ModelState.AddModelError("PrescriptionFile", "Prescription file is required.");
                return BadRequest(ModelState);
            }

            var medicalSuppliesRequest = new MedicalSuppliesRequest

            {
                UserName = dto.UserName,
                Address = dto.Address,
                MedicationName = dto.MedicationName,
                DeliveryTime = dto.DeliveryTime,
                PrescriptionFilePath = filepath,
            };

            _db.MedicalSuppliesRequests.Add(medicalSuppliesRequest);
            _db.SaveChanges();

            return Ok(new { message = "Your request has been submitted successfully!" });

        }

    }
}



