using System;
using
System.ComponentModel.DataAnnotations;

namespace HASS_v1.Models

{
        public class MedicalRecord
        {
            public int MedicalRecordId { get; set; }

            [Required]
            public string PatientId { get; set; }

            [Required]
            public string Diagnosis { get; set; }

            [Required]
            public string Treatment { get; set; }

            public DateTime RecordDate { get; set; }

            [Required]
            public string DoctorId { get; set; } // Doctor who treated the patient

            public string AdditionalNotes { get; set; }
        }
    }

