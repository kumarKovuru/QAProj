using eMids.QA.Application.Common.Config;
using eMids.QA.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace eMids.QA.Application.Test
{
    [Binding]
    public class NewPatientRegistrationUsingAPISteps
    {
        private HttpResponseMessage _result;
        private string webURL = "https://localhost:5001/api/";

        [When(@"User Calls NewPatientRegistrationUsingAPI method")]
        public void WhenUserCallsNewPatientRegistrationUsingAPIMethod()
        {
            PatientController con = new PatientController();
            Common.Patient patient = new Common.Patient()
            {
                FirstName = Convert.ToString((ScenarioContext.Current["FirstName"])),
                LastName = Convert.ToString((ScenarioContext.Current["LastName"])),
                MemberId = Convert.ToString((ScenarioContext.Current["MemberId"]))
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webURL);
                var responseTask = client.PostAsJsonAsync<Common.Patient>("Patient/CreatePatient", patient);
                responseTask.Wait();
                _result = responseTask.Result;
            }
        }

        [Then(@"NewPatientRegistrationUsingAPI is successful")]
        public void ThenNewPatientRegistrationUsingAPIIsSuccessful()
        {
            Assert.IsTrue(_result.IsSuccessStatusCode);
        }
    }
}
