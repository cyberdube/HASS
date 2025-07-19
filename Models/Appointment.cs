
using System;
using System.ComponentModel.DataAnnotations;

namespace HASS_v1.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required]
        public string PatientId { get; set; }

        [Required]
        public string DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        //public Doctor Doctor { get; set; } //navigate property to doctor

        public string Status { get; set; } // e.g., Scheduled, Completed, Canceled
    }
}
