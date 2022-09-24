using Microsoft.AspNetCore.Mvc;

namespace Patient_Managment_System.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewUser()
        {
            return View();
        }

        public IActionResult RemoveUser()
        {
            return View();
        }
    }
}
