using Microsoft.AspNetCore.Mvc;
using Patient_Managment_System.Models.Services;

namespace Patient_Managment_System.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IUserService _setuserService;
        private int uId;
        public SettingsController(IUserService userService)
        {
            _setuserService = userService;
        }
        public IActionResult Index(int id)
        {
            uId = id;
            return View();
        }

    }
}
