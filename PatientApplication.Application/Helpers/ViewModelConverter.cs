using System.Globalization;
using PatientApplication.Application.ViewModels;
using PatientApplication.Data.Entities;
using PatientApplication.Data.Enums;

namespace PatientApplication.Application.Helpers
{
    public class ViewModelConverter
    {
        public static Patient PatientConverter(PatientViewModel viewModel)
        {
            return new Patient
            {
                Id = Guid.Parse(viewModel.Name.Id),
                BirthDate = DateTime.Parse(viewModel.BirthDate),
                Gender = Enum.Parse<Gender>(viewModel.Gender, true),
                IsActive = viewModel.IsActive,
                Name = new Name
                {
                    Id = Guid.Parse(viewModel.Name.Id),
                    Family = viewModel.Name.Family,
                    Given = viewModel.Name.Given,
                    Use = viewModel.Name.Use
                }
            };
        }

        public static PatientViewModel PatientConverter(Patient viewModel)
        {
            return new PatientViewModel()
            {
                BirthDate = viewModel.BirthDate.ToString(CultureInfo.InvariantCulture),
                Gender = Enum.GetName(viewModel.Gender) ?? string.Empty,
                IsActive = viewModel.IsActive,
                Name = new NameViewModel()
                {
                    Id = viewModel.Name.Id.ToString(),
                    Family = viewModel.Name.Family,
                    Given = viewModel.Name.Given,
                    Use = viewModel.Name.Use
                }
            };
        }
    }
}
