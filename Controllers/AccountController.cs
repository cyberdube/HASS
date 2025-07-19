using HASS_v1.Data;

using HASS_v1.Models;

using Microsoft.AspNetCore.Mvc;



namespace HASS_v1.Controllers

{

    public class AccountController : Controller

    {

        private readonly ApplicationDbContext _context;



        public AccountController(ApplicationDbContext context)

        {

            _context = context;

        }



        [HttpGet]

        public IActionResult Login()

        {

            return View();

        }



        
[HttpPost]
public IActionResult Login(string username, string password)
{
    var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

    if (user != null)
    {
        HttpContext.Session.SetString("UserRole", user.Role);
        HttpContext.Session.SetInt32("UserId", user.UserId);

        if (user.Role == "Admin")
            return RedirectToAction("Privacy", "Home");
        else
            return RedirectToAction("Dashboard", "Patient");
    }

    ViewBag.Error = "Invalid username or password.";
    return View();
}


        [HttpGet]
        public IActionResult Register()
        {

            return View(); // No need to specify "Patient/Register"

        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            user.Role = "Patient";
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }


        public IActionResult Logout()

        {

            HttpContext.Session.Clear();

            return RedirectToAction("Login");

        }

    }

}

