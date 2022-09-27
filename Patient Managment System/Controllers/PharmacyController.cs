using Microsoft.AspNetCore.Mvc;
using Patient_Managment_System.Models;
using Patient_Managment_System.Models.Services;

namespace Patient_Managment_System.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly IPrescriptiondrugService _prescriptionDrugService;
        private readonly IBillService _billService;
        private readonly IDrugService _drugService;
        public PharmacyController(IDrugService drugService,IBillService billService,IPrescriptiondrugService prescriptionDrugService)
        {
            _prescriptionDrugService = prescriptionDrugService;
            _billService = billService;
            _drugService = drugService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Shop()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Shop(int Id)
        {
            var meds = await _prescriptionDrugService.GetByIdAsync(Id);
            ViewBag.medOrder = meds.Type + "\n" + meds.Advice;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShopingBill(Bill bill)
        {
            await _billService.AddAsync(bill);
            return RedirectToAction(nameof(Shop));
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Drug drug)
        {
            drug.Avaliable = 0;
            await _drugService.AddAsync(drug);
            return View();
        }
    }
}
