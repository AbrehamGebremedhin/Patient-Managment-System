using Microsoft.AspNetCore.Mvc;

namespace Patient_Managment_System.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            return View();
        }

        public IActionResult Certificate()
        {
            return View();
        }

        public IActionResult newAppointment()
        {
            return View();
        }
    }
}
