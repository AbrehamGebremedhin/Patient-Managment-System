using Microsoft.AspNetCore.Mvc;
using Patient_Managment_System.Models;
using Patient_Managment_System.Models.Services;
using System.Diagnostics;

namespace Patient_Managment_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly pmsContext _context;
        private readonly IUserService _userService;
        public HomeController(pmsContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var email = _context.Users.Where(temp => temp.Email.Contains(username)).Select(p => p.Email).FirstOrDefault();
            var pass = _context.Users.Where(temp => temp.Email.Contains(username)).Select(p => p.Password).FirstOrDefault();
            var urole = _context.Users.Where(temp => temp.Email.Contains(username)).Select(p => p.Role).FirstOrDefault();
            var uId = _context.Users.Where(temp => temp.Email.Contains(username)).Select(p => p.Id).FirstOrDefault();
            LoginModel loginModel = new LoginModel();
            loginModel.Id = uId;
            loginModel.role = urole;
            if (username.Equals(email))
            {
                if (password.Equals(pass))
                {
                    return RedirectToRoute(new
                    {
                        controller = loginModel.role,
                        action = "Index",
                        Id = uId,
                        role = urole
                    }); ;
                }
                else
                {
                    return RedirectToRoute(new
                    {
                        controller = "Error",
                        action = "Password"
                    });
                }
            }
            else
            {
                return RedirectToRoute(new
                {
                    controller = "Error",
                    action = "Email"
                });
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}