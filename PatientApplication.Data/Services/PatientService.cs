using PatientApplication.Data.Entities;
using PatientApplication.Data.Enums;
using PatientApplication.Data.Interfaces;
using PatientApplication.Data.Services.Base;

namespace PatientApplication.Data.Services;

public class PatientService : BaseService<Patient, Guid>, IPatientService
{
    private readonly PatientContext _context;

    public PatientService(PatientContext context) : base(context)
    {
        _context = context;
    }

    public List<Patient> GetByBirthDate(DateTime startDate, DateTime endDate)
        => _context.Set<Patient>().Where(x => x.BirthDate >= startDate && x.BirthDate <= endDate).ToList();

    public List<Patient> GetByBirthDate(DateTime date, Filter? filter)
    {
        return filter switch
        {
            Filter.Ne => _context.Set<Patient>().Where(x => x.BirthDate.Date != date.Date)
                .Join(_context.Set<Name>(), p => p.Id, name => name.Id, (patient, name) => new Patient()
            {
                BirthDate = patient.BirthDate,
                Gender = patient.Gender,
                Id = patient.Id,
                IsActive = patient.IsActive,
                Name = name
            }).ToList(),
            Filter.Lt => _context.Set<Patient>().Where(x => x.BirthDate < date)
                .Join(_context.Set<Name>(), p => p.Id, name => name.Id, (patient, name) => new Patient()
                {
                    BirthDate = patient.BirthDate,
                    Gender = patient.Gender,
                    Id = patient.Id,
                    IsActive = patient.IsActive,
                    Name = name
                }).ToList(),
            Filter.Gt => _context.Set<Patient>().Where(x => x.BirthDate > date)
                .Join(_context.Set<Name>(), p => p.Id, name => name.Id, (patient, name) => new Patient()
                {
                    BirthDate = patient.BirthDate,
                    Gender = patient.Gender,
                    Id = patient.Id,
                    IsActive = patient.IsActive,
                    Name = name
                }).ToList(),
            Filter.Le => _context.Set<Patient>().Where(x => x.BirthDate <= date)
                .Join(_context.Set<Name>(), p => p.Id, name => name.Id, (patient, name) => new Patient()
                {
                    BirthDate = patient.BirthDate,
                    Gender = patient.Gender,
                    Id = patient.Id,
                    IsActive = patient.IsActive,
                    Name = name
                }).ToList(),
            Filter.Ge => _context.Set<Patient>().Where(x => x.BirthDate >= date)
                .Join(_context.Set<Name>(), p => p.Id, name => name.Id, (patient, name) => new Patient()
                {
                    BirthDate = patient.BirthDate,
                    Gender = patient.Gender,
                    Id = patient.Id,
                    IsActive = patient.IsActive,
                    Name = name
                }).ToList(),
            //
            Filter.Sa => _context.Set<Patient>().Where(x => x.BirthDate >= date)
                .Join(_context.Set<Name>(), p => p.Id, name => name.Id, (patient, name) => new Patient()
                {
                    BirthDate = patient.BirthDate,
                    Gender = patient.Gender,
                    Id = patient.Id,
                    IsActive = patient.IsActive,
                    Name = name
                }).ToList(),
            Filter.Eb => _context.Set<Patient>().Where(x => x.BirthDate >= date)
                .Join(_context.Set<Name>(), p => p.Id, name => name.Id, (patient, name) => new Patient()
                {
                    BirthDate = patient.BirthDate,
                    Gender = patient.Gender,
                    Id = patient.Id,
                    IsActive = patient.IsActive,
                    Name = name
                }).ToList(),
            Filter.Ap => _context.Set<Patient>().Where(x => x.BirthDate >= date)
                .Join(_context.Set<Name>(), p => p.Id, name => name.Id, (patient, name) => new Patient()
                {
                    BirthDate = patient.BirthDate,
                    Gender = patient.Gender,
                    Id = patient.Id,
                    IsActive = patient.IsActive,
                    Name = name
                }).ToList(),
            Filter.Eq => _context.Set<Patient>().Where(x => x.BirthDate.Date == date.Date)
                .Join(_context.Set<Name>(), p => p.Id, name => name.Id, (patient, name) => new Patient()
                {
                    BirthDate = patient.BirthDate,
                    Gender = patient.Gender,
                    Id = patient.Id,
                    IsActive = patient.IsActive,
                    Name = name
                }).ToList(),
            _ => _context.Set<Patient>().Where(x => x.BirthDate.Date == date.Date)
                .Join(_context.Set<Name>(), p => p.Id, name => name.Id, (patient, name) => new Patient()
                {
                    BirthDate = patient.BirthDate,
                    Gender = patient.Gender,
                    Id = patient.Id,
                    IsActive = patient.IsActive,
                    Name = name
                }).ToList()
        };
    }
}