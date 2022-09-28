using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using Patient_Managment_System.Models;
using Patient_Managment_System.Models.Services;

namespace Patient_Managment_System.Controllers
{
    public class LabratoryController : Controller
    {
        private readonly IPrescriptiontestService _prescriptiontestService;
        private readonly IOrderHistoryService _orderHistoryService;
        public LabratoryController(IPrescriptiontestService prescriptiontestService, IOrderHistoryService orderHistoryService)
        {
            _prescriptiontestService = prescriptiontestService;
            _orderHistoryService = orderHistoryService;
        }
        public async Task<IActionResult> Index(int id)
        {
            return View();
        }
        public async Task<IActionResult> Order()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Order(int Id)
        {
            var order = await _orderHistoryService.GetByIdAsync(Id);
            ViewBag.LabOrder = order.LabOrder;
            TempData["Description"] = order.LabOrder;
            TempData["Id"] = order.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Result(string result)
        {
            Prescriptiontest prescriptiontest = new Prescriptiontest();
            prescriptiontest.Result = result;
            if (TempData.ContainsKey("Description"))
            {
                prescriptiontest.Description = TempData["Description"].ToString();
                prescriptiontest.Id = Convert.ToInt32(TempData["Id"]);
            }
            await _prescriptiontestService.AddAsync(prescriptiontest);
            return RedirectToAction(nameof(Order));
        }
    }
}
