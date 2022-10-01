using Microsoft.AspNetCore.Mvc;
using Patient_Managment_System.Models;
using Patient_Managment_System.Models.Services;

namespace Patient_Managment_System.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IBillService _billService;
        private readonly IAppointmentService _appointmentService;
        public ReceptionController(IPatientService patientService, IBillService billService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _billService = billService;
            _appointmentService = appointmentService;
        }

        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            ViewBag.Id = loginModel.Id;
            ViewBag.role = loginModel.role;
            return View();
        }

        public async Task<IActionResult> NewPatient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewPatient(Patient patient)
        {
            await _patientService.AddAsync(patient);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Appointment()
        {
            var appointments = await _appointmentService.GetAllAsync();
            return View(appointments);
        }
        public async Task<IActionResult> BillMenu()
        {
            var data = await _billService.GetAllAsync();
            return View(data);
        }
    }
}
