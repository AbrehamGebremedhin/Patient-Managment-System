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
            var role = _context.Users.Where(temp => temp.Email.Contains(username)).Select(p => p.Role).FirstOrDefault();
            var uId = _context.Users.Where(temp => temp.Email.Contains(username)).Select(p => p.Id).FirstOrDefault();
            if (username.Equals(email))
            {
                if (password.Equals(pass))
                {
                    return RedirectToRoute(new
                    {
                        controller = role,
                        action = "Index",
                        Id = uId
                    }); ;
                }
            }
            else
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Error"
                });
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string username,string RememberPhrase,string password)
        {
            var email = _context.Users.Where(temp => temp.Email.Contains(username)).Select(p => p.Email).FirstOrDefault();
            var id = _context.Users.Where(temp => temp.Email.Contains(username)).Select(p => p.Id).FirstOrDefault();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}