using eMids.QA.Application.Common.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace eMids.QA.Application.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationConfiguration appConfig;
        public PatientController(IOptions<ApplicationConfiguration> configuration)
        {
            appConfig = configuration.Value;
        }
        public IActionResult Index()
        {
            List<Common.Patient> patients = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(appConfig.WebAPIUrl);
                var responseTask = client.GetAsync("Patient/GetPatientList");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Common.Patient>>();
                    readTask.Wait();
                    patients = readTask.Result;
                }
                else
                {
                    patients = new List<Common.Patient>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(patients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Common.Patient patient = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(appConfig.WebAPIUrl);
                var responseTask = client.GetAsync("Patient/GetPatientById?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Common.Patient>();
                    readTask.Wait();
                    patient = readTask.Result;
                }
                else
                {
                    patient = new Common.Patient();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(patient);
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Common.Patient patient = new Common.Patient()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    MemberId = collection["MemberId"]
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(appConfig.WebAPIUrl);
                    var responseTask = client.PostAsJsonAsync<Common.Patient>("Patient/CreatePatient", patient);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            Common.Patient patient = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(appConfig.WebAPIUrl);
                var responseTask = client.GetAsync("Patient/GetPatientById?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Common.Patient>();
                    readTask.Wait();
                    patient = readTask.Result;
                }
                else
                {
                    patient = new Common.Patient();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(patient);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                Common.Patient patient = new Common.Patient()
                {
                    PatientId = Convert.ToInt32(collection["PatientId"]),
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    MemberId = collection["MemberId"]
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(appConfig.WebAPIUrl);
                    var responseTask = client.PutAsJsonAsync<Common.Patient>("Patient/UpdatePatient", patient);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        // POST: Todo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(appConfig.WebAPIUrl);
                    var responseTask = client.DeleteAsync("Patient/DeletePatient?id=" + id.ToString());
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
