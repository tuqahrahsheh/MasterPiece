using System.ComponentModel.DataAnnotations;

namespace Masterpro_1.DTOs
{
    public class MedicalSuppliesRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string MedicationName { get; set; }

        [Required]
        public DateTime DeliveryTime { get; set; }

        [Required]
        public IFormFile PrescriptionFile { get; set; }
    }
}
