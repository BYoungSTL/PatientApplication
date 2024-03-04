using PatientApplication.Data.Entities;
using PatientApplication.Data.Interfaces;
using PatientApplication.Data.Services.Base;

namespace PatientApplication.Data.Services
{
    public class NameService : BaseService<Name, Guid>, INameService
    {
        private readonly PatientContext _context;
        public NameService(PatientContext context) : base(context)
        {
            _context = context;
        }
    }
}
