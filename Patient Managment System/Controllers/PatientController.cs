using Microsoft.AspNetCore.Mvc;
using Patient_Managment_System.Models;
using Patient_Managment_System.Models.Services;

namespace Patient_Managment_System.Controllers
{
    public class PatientController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public PatientController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index(LoginModel loginModel)
        {
            ViewBag.Id = loginModel.Id;
            ViewBag.role = loginModel.role;
            TempData["patId"] = loginModel.Id;
            return View();
        }

        public async Task<IActionResult> Appointment()
        {
            int pId = Convert.ToInt32(TempData["patId"]);
            var appointment = await _appointmentService.GetByIdAsync(pId);
            ViewBag.Date = appointment.NextAppointment;
            return View();
        }


        public async Task<IActionResult> newAppointment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> newAppointment(Appointment appointment)
        {
            await _appointmentService.AddAsync(appointment);
            return RedirectToAction(nameof(Index));
        }

    }
}
