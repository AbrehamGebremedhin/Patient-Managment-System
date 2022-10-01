using Microsoft.AspNetCore.Mvc;

namespace Patient_Managment_System.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
