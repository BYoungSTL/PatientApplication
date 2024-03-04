using Microsoft.AspNetCore.Mvc;
using PatientApplication.Application.Interfaces;
using PatientApplication.Application.ViewModels;

namespace PatientApplication.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientAppService _patientAppService;
        public PatientController(IPatientAppService patientAppService)
        {
            _patientAppService = patientAppService;
        }

        [HttpGet("id")]
        public IActionResult GetById(string id)
        {
            return Ok(_patientAppService.GetById(id));
        }

        [HttpGet("/getByDate")]
        public IActionResult GetByDate(string date)
        {
            return Ok(_patientAppService.GetByDate(date));
        }

        [HttpGet("/getByDateRange")]
        public IActionResult GetByDateRange(string date)
        {
            return Ok(_patientAppService.GetByDate(date));
        }

        [HttpPost("/addMany")]
        public IActionResult Add([FromBody] PatientViewModel[] viewModels)
        {
            return Ok(_patientAppService.Add(viewModels));
        }

        [HttpPost("/add")]
        public IActionResult Add([FromBody] PatientViewModel viewModel)
        {
            return Ok(_patientAppService.Add(viewModel));
        }

        [HttpPatch("/update")]
        public IActionResult Update([FromBody] PatientViewModel viewModel)
        {
            return Ok(_patientAppService.Update(viewModel));
        }

        [HttpDelete("/delete")]
        public IActionResult Delete(string id)
        {
            return Ok(_patientAppService.Delete(id));
        }
    }
}
