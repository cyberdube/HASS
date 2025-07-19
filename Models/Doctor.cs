using System.ComponentModel.DataAnnotations;

namespace HASS_v1.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        [Required]
        [StringLength(100)]
        public string Speciality { get; set; }


        [Required]
        [StringLength(100)]
        public string Availability { get; set; }

    }
}
