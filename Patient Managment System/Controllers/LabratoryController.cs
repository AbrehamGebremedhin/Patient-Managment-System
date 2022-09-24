using Microsoft.AspNetCore.Mvc;

namespace Patient_Managment_System.Controllers
{
    public class LabratoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Order()
        {
            return View();
        }
    }
}
