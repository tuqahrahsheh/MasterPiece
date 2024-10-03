using Masterpro_1.DTOs;
using Masterpro_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Masterpro_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly MyDbContext _db;

        public ContactController(MyDbContext db)
        {
            _db = db;
        }

        // GET: api/Contact
        [HttpPost]
        public IActionResult Contact([FromForm] ContactRequestDTO DTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = new ContactMessage
            {
                Name = DTO.Name,
                Email = DTO.Email,
                Message = DTO.Message,
                Subject = DTO.Subject,
                DateSent = DateTime.Now
            };
           _db.ContactMessages.Add(contact);
            _db.SaveChanges();


            return Ok(contact);
        }

        [HttpGet("contact")]
        public IActionResult GetContact()
        {
            var contact = _db.ContactMessages.ToList();
            return Ok(contact);
        }

    }
}
