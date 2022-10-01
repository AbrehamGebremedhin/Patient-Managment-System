using Microsoft.AspNetCore.Mvc;
using Patient_Managment_System.Models;
using Patient_Managment_System.Models.Services;

namespace Patient_Managment_System.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IUserService _userService;
        public SettingsController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index(int Id,string role)
        {
            ViewBag.uId = Id;
            ViewBag.role = role;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int id,User user)
        {
            await _userService.UpdateAsync(id,user);
            return RedirectToAction(nameof(Index));
        }
    }
}
