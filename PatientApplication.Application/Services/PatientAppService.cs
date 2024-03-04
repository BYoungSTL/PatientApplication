using PatientApplication.Application.Helpers;
using PatientApplication.Application.Interfaces;
using PatientApplication.Application.ViewModels;
using PatientApplication.Data.Entities;
using PatientApplication.Data.Enums;
using PatientApplication.Data.Interfaces;

namespace PatientApplication.Application.Services
{
    public class PatientAppService : IPatientAppService
    {
        private readonly IPatientService _patientService;
        private readonly INameService _nameService;
        public PatientAppService(IPatientService patientService, INameService nameService)
        {
            _patientService = patientService;
            _nameService = nameService;
        }

        /// <summary>
        /// param looks like eq2013-01-14 or lt2013-01-14T10:00
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IEnumerable<Patient> GetByDate(string date)
        {
            var filterValue = Enum.Parse<Filter>(date[..2], true);
            date = date.Remove(0, 2);

            var parsedDate = DateTime.Parse(date);

            return _patientService.GetByBirthDate(parsedDate, filterValue);
        }

        public IEnumerable<Patient> GetByDateRange(string startDate, string endDate)
        {
            var startDateTime = DateTime.Parse(startDate);
            var endDateTime = DateTime.Parse(endDate);

            return _patientService.GetByBirthDate(startDateTime, endDateTime);
        }

        public bool Add(IEnumerable<PatientViewModel> viewModels)
        {
            try
            {
                foreach (var viewModel in viewModels)
                    _patientService.Add(ViewModelConverter.PatientConverter(viewModel));
            }
            catch (Exception e)
            {
                //log
                return false;
            }

            return true;
        }

        public bool Add(PatientViewModel viewModel)
        {
            try
            {
                _patientService.Add(ViewModelConverter.PatientConverter(viewModel));
            }
            catch (Exception e)
            {
                //log
                return false;
            }

            return true;
        }

        public bool Update(PatientViewModel viewModel)
        {
            try
            {
                _patientService.Update(ViewModelConverter.PatientConverter(viewModel));
            }
            catch (Exception e)
            {
                //log
                return false;
            }

            return true;
        }

        public bool Delete(string id)
        {
            var guid = Guid.Parse(id);

            if (guid == Guid.Empty)
                throw new ArgumentNullException(nameof(guid));

            return _patientService.Delete(guid);
        }

        public PatientViewModel GetById(string id)
        {
            var guid = Guid.Parse(id);

            if (guid == Guid.Empty)
                throw new ArgumentNullException(nameof(guid));

            var patient = _patientService.GetById(guid);

            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            var name = _nameService.GetById(guid);

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            patient.Name = name;

            return ViewModelConverter.PatientConverter(patient);
        }
    }
}
