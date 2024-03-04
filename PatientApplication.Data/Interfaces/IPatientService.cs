using PatientApplication.Data.Entities;
using PatientApplication.Data.Enums;
using PatientApplication.Data.Interfaces.Base;

namespace PatientApplication.Data.Interfaces;

public interface IPatientService : IBaseService<Patient, Guid>
{
    public List<Patient> GetByBirthDate(DateTime startDate, DateTime endDate);

    public List<Patient> GetByBirthDate(DateTime date, Filter? filter);
}