using Patient_Managment_System.Models.Base;

namespace Patient_Managment_System.Models.Services
{
    public class BillService : EntityBaseRepository<Bill>, IBillService
    {
        private readonly pmsContext _context;
        public BillService(pmsContext context) : base(context)
        {
            _context = context;
        }
    }
}
