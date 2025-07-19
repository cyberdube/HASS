using HASS_v1.Data;
using HASS_v1.Filters;
using HASS_v1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace HASS_v1.Controllers
{
    [ServiceFilter(typeof(PatientAuthorizationFilter))]
    public class PatientAppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientAppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.DoctorList = new SelectList(_context.Doctors.Where(d => d.Availability == "Available"), "DoctorId", "Name");
            return View(); // Ensure this returns the correct view
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            appointment.PatientId = HttpContext.Session.GetInt32("UserId").ToString();
            appointment.Status = "Scheduled";
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "Patient"); // Redirect to the appropriate action
        }

        public IActionResult MyAppointments()
        {
            var patientId = HttpContext.Session.GetInt32("UserId").ToString();
            var appointments = _context.Appointments.Where(a => a.PatientId == patientId).ToList();
            return View(appointments); // Pass the appointments list to the view
        }
    }
}
