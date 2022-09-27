using Patient_Managment_System.Models.Base;

namespace Patient_Managment_System.Models.Services
{
    public class DrugService : EntityBaseRepository<Drug>, IDrugService
    {
        private readonly pmsContext _context;
        public DrugService(pmsContext context) : base(context)
        {
            _context = context;
        }
    }
}
