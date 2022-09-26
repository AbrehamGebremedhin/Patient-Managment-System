using Patient_Managment_System.Models.Base;

namespace Patient_Managment_System.Models.Services
{
    public class PrescriptiondrugService : EntityBaseRepository<Prescriptiondrug>, IPrescriptiondrugService
    {
        private readonly pmsContext _context;
        public PrescriptiondrugService(pmsContext context) : base(context)
        {
            _context = context;
        }
    }
}
