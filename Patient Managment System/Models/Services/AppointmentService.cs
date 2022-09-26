using Patient_Managment_System.Models.Base;

namespace Patient_Managment_System.Models.Services
{
    public class AppointmentService : EntityBaseRepository<Appointment>, IAppointmentService
    {
        private readonly pmsContext _context;
        public AppointmentService(pmsContext context) : base(context)
        {
            _context = context;
        }
    }
}
