using Microsoft.AspNetCore.Mvc;
using Patient_Managment_System.Models;
using Patient_Managment_System.Models.Services;
using Syncfusion;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace Patient_Managment_System.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IOrderHistoryService _orderHistoryService;
        private readonly IPatientDiagService _patientDiagService;
        private readonly IPatientService _patientService;
        private readonly IPrescriptiontestService _prescriptiontest;
        private readonly IPrescriptiondrugService _prescriptiondrug;
        public DoctorController(IPrescriptiondrugService prescriptiondrug,IPrescriptiontestService prescriptiontest, IOrderHistoryService orderHistoryService,IPatientDiagService patientDiagService, IPatientService patientService)
        {
            _orderHistoryService = orderHistoryService;
            _patientDiagService = patientDiagService;
            _patientService = patientService;
            _prescriptiontest = prescriptiontest;
            _prescriptiondrug = prescriptiondrug;
        }
        public IActionResult Index(int id)
        {
            ViewBag.uId = id;
            return View();
        }

        public async Task<IActionResult> Preliminary()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Preliminary(OrderHistory orderHistory)
        {
            orderHistory.PatientId = orderHistory.Id;
            await _orderHistoryService.AddAsync(orderHistory);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Diagnosis()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Diagnosis(int Id)
        {
            var lab = await _prescriptiontest.GetByIdAsync(Id);
            ViewBag.Result = lab.Result;
            TempData["Id"] = lab.Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PatientDiagnosis(PatientDiag patientDiag)
        {
            await _patientDiagService.AddAsync(patientDiag);
            return RedirectToAction(nameof(Diagnosis));
        }

        public async Task<IActionResult> Medicine()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Medicine(Prescriptiondrug prescriptiondrug)
        {
            await _prescriptiondrug.AddAsync(prescriptiondrug);
            return RedirectToAction(nameof(Medicine));
        }

        public async Task<IActionResult> Certificate()
        {        
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Certificate(string PatientId, string Diagnosis, string noOfDays, string currentDate, string PhysicianName)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics1 = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont writingFont = new PdfStandardFont(PdfFontFamily.Helvetica, 13);
            graphics1.DrawString("Patient Managment System\n Diagnosis: " + Diagnosis + "\nRecommended days for rest: " + noOfDays + "\nDate: " + currentDate + "\nPhysician Name: Dr." + PhysicianName, font, PdfBrushes.Black, new PointF(0, 0));

            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;

            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "Certificate.pdf";
            return fileStreamResult;
        }
    }
}
