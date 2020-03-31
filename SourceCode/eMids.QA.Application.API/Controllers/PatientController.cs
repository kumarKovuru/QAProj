using eMids.QA.Application.Business;
using eMids.QA.Application.Business.Patient;
using Microsoft.AspNetCore.Mvc;

namespace eMids.QA.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientBusiness _patientBusiness;

        public PatientController()
        {
            _patientBusiness = new PatientBusiness();
        }

        [HttpGet]
        [Route("GetPatientList")]
        public IActionResult GetPatientList()
        {
            var patients = _patientBusiness.GetPatientList();
            return Ok(patients);
        }

        [HttpGet]
        [Route("GetPatientById")]
        public IActionResult GetById(int id)
        {
            var patient = _patientBusiness.GetById(id);
            return Ok(patient);
        }

        [HttpPost]
        [Route("CreatePatient")]
        public IActionResult Create(Common.Patient patient)
        {
            int id = _patientBusiness.Create(patient);
            return Ok(id);
        }

        [HttpPut]
        [Route("UpdatePatient")]
        public ActionResult Edit(Common.Patient patient)
        {
            _patientBusiness.Edit(patient);
            return Ok();
        }

        [HttpDelete]
        [Route("DeletePatient")]
        public ActionResult Delete(int id)
        {
            _patientBusiness.Delete(id);
            return Ok();
        }
    }
}

