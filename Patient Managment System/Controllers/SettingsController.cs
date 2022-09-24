using Microsoft.AspNetCore.Mvc;

namespace Patient_Managment_System.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult password()
        {
            return View();
        }

        public IActionResult email()
        {
            return View();
        }

        public IActionResult token()
        {
            return View();
        }
    }
}
