using Microsoft.AspNetCore.Mvc;
using Patient_Managment_System.Models;
using Patient_Managment_System.Models.Services;

namespace Patient_Managment_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            ViewBag.Id = loginModel.Id;
            ViewBag.role = loginModel.role;
            var data = await _userService.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> NewUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewUser(User user)
        {
            await _userService.AddAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveUser(int Id)
        {
            var user = await _userService.GetByIdAsync(Id);
            if (user == null) return View("NotFound");
            return View(user);
        }
        [HttpPost, ActionName("RemoveUser")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var data = await _userService.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateUser(int Id)
        {
            var data = await _userService.GetByIdAsync(Id);
            if (data == null) return View("NotFound");
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            await _userService.UpdateAsync(id, user);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("RemoveUser")]
        public async Task<IActionResult> UpdateConfirm(int id)
        {
            var data = await _userService.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
