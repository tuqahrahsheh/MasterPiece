namespace Masterpro_1.DTOs
{
   
        public class DoctorRequestDTO
        {
            public string? Name { get; set; }
            public string? Specialty { get; set; }
            public string? Description { get; set; }
            public string? ContactEmail { get; set; }
            public IFormFile? DoctorImage { get; set; }
        }
}
