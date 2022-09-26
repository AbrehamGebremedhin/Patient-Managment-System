using Patient_Managment_System.Models.Base;

namespace Patient_Managment_System.Models.Services
{
    public class UserService : EntityBaseRepository<User>, IUserService
    {
        private readonly pmsContext _context;
        public UserService(pmsContext context) : base(context)
        {
            _context = context;
        }
    }
}
