using Patient_Managment_System.Models.Base;

namespace Patient_Managment_System.Models.Services
{
    public class PatientDiagService : EntityBaseRepository<PatientDiag> ,IPatientDiagService
    {
        private readonly pmsContext _pmsContext;

        public PatientDiagService(pmsContext context) : base(context)
        {
            _pmsContext = context;
        }
    }
}
