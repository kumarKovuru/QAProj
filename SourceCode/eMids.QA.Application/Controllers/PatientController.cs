using eMids.QA.Application.Business;
using eMids.QA.Application.Business.Patient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eMids.QA.Application.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientBusiness _patientBusiness;

        public PatientController()
        {
            _patientBusiness = new PatientBusiness();
        }
        public IActionResult Index()
        {
            var patients = _patientBusiness.GetPatientList();
            return View(patients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var patient = _patientBusiness.GetById(id);
            return View(patient);
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _patientBusiness.Create(new Common.Patient { FirstName = collection["FirstName"], LastName = collection["LastName"], MemberId = collection["MemberId"] });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var patient = _patientBusiness.GetById(id);
            return View(patient);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                _patientBusiness.Edit(new Common.Patient { PatientId = Convert.ToInt32(collection["PatientId"]), FirstName = collection["FirstName"], LastName = collection["LastName"], MemberId = collection["MemberId"] });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            return View("~/Views/Patient/Delete.cshtml", _patientBusiness.GetById(id));
        }

        // POST: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _patientBusiness.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
