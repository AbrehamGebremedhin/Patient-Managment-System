using Patient_Managment_System.Models.Base;

namespace Patient_Managment_System.Models.Services
{
    public class OrderHistoryService : EntityBaseRepository<OrderHistory>, IOrderHistoryService
    {
        private readonly pmsContext _context;
        public OrderHistoryService(pmsContext context) : base(context)
        {
            _context = context;
        }
    }
}
