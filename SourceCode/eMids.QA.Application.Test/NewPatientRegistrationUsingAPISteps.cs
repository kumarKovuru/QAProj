using eMids.QA.Application.Controllers;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace eMids.QA.Application.Test
{
    [Binding]
    public class NewPatientRegistrationUsingAPISteps
    {
        private HttpResponseMessage _result;
        static int patientId;
        private string webURL = "http://172.16.103.51:5070/api/";

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
            using (HttpContent content = _result.Content)
            {
                // ... Read the string.
                Task<string> result = content.ReadAsStringAsync();
                patientId = Convert.ToInt32(result.Result);
            }
            Assert.IsTrue(_result.IsSuccessStatusCode);
        }


        [When(@"User Searches newly created patient id in database with API")]

        public void WhenUserSearchesNewlyCreatedPatientIdInDatabaseWithoutAPI()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webURL);
                var responseTask = client.GetAsync("Patient/GetPatientById?id=" + patientId.ToString());
                responseTask.Wait();
                _result = responseTask.Result;
            }

        }

        [Then(@"search result will have one record with API")]
        public void ThenSearchResultWillHaveOneRecordWithAPI()
        {
            Assert.IsTrue(_result.IsSuccessStatusCode);
            Common.Patient patients = null;
            if (_result.IsSuccessStatusCode)
            {
                var readTask = _result.Content.ReadAsAsync<Common.Patient>();
                readTask.Wait();
                patients = readTask.Result;
            }
            Assert.IsTrue(patients != null);
        }

    }
}
