using Microsoft.AspNetCore.Mvc;

namespace Patient_Managment_System.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Email()
        {
            return View();
        }

        public IActionResult Password()
        {
            return View();
        }
    }
}
