using Microsoft.AspNetCore.Mvc;

namespace Patient_Managment_System.Controllers
{
    public class PharmacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
