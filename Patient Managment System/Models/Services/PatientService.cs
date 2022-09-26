using Patient_Managment_System.Models.Base;

namespace Patient_Managment_System.Models.Services
{
    public class PatientService : EntityBaseRepository<Patient>, IPatientService
    {
        private readonly pmsContext _context;
        public PatientService(pmsContext context) : base(context)
        {
            _context = context;
        }
    }
}
