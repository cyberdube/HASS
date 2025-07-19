using HASS_v1.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HASS_v1.Controllers
{

    [ServiceFilter(typeof(PatientAuthorizationFilter))]
    public class PatientController : Controller
    {
        public IActionResult Dashboard()
        {
            return View(); // No need to specify the path
 
        }
    }

}
