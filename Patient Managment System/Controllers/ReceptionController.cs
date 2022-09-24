using Microsoft.AspNetCore.Mvc;

namespace Patient_Managment_System.Controllers
{
    public class ReceptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewPatient()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            return View();
        }
        public IActionResult BillMenu()
        {
            return View();
        }
    }
}
