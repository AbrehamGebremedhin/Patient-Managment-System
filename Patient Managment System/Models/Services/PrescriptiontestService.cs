using Patient_Managment_System.Models.Base;

namespace Patient_Managment_System.Models.Services
{
    public class PrescriptiontestService : EntityBaseRepository<Prescriptiontest>, IPrescriptiontestService
    {
        private readonly pmsContext _context;
        public PrescriptiontestService(pmsContext context) : base(context)
        {
            _context = context;
        }
    }
}
