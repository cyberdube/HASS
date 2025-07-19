using HASS_v1.Data;
using HASS_v1.Filters;
using HASS_v1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HASS_v1.Controllers
{
    [ServiceFilter(typeof(PatientAuthorizationFilter))]
    public class PatientMedicalRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientMedicalRecordController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MyRecords()
        {
            var patientId = HttpContext.Session.GetInt32("UserId").ToString();
            var records = _context.MedicalRecords.Where(r => r.PatientId == patientId).ToList();
            return View(records); // Pass the records list to the view
        }
    }
}
