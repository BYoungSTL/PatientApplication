using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Application.ViewModels
{
    public class NameViewModel
    {
        public string Id { get; set; }

        public string Use { get; set; }

        public string Family { get; set; }

        public string[] Given { get; set; }
    }
}
