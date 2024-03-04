using PatientApplication.Application.ViewModels;
using PatientApplication.Data.Entities;

namespace PatientApplication.Application.Interfaces
{
    public interface IPatientAppService
    {
        public IEnumerable<Patient> GetByDate(string date);

        public IEnumerable<Patient> GetByDateRange(string startDate, string endDate);

        public bool Add(IEnumerable<PatientViewModel> patients);

        public bool Add(PatientViewModel patient);

        public bool Update(PatientViewModel viewModel);

        public bool Delete(string id);
        public PatientViewModel GetById(string id);
    }
}
