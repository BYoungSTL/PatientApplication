using PatientApplication.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Application.ViewModels
{
    public class PatientViewModel
    {

        public string Gender { get; set; }

        public string BirthDate { get; set; }

        public bool IsActive { get; set; }

        public NameViewModel Name { get; set; }
    }
}
