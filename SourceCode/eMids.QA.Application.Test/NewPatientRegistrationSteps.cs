using eMids.QA.Application.Common.Config;
using eMids.QA.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace eMids.QA.Application.Test
{
    [Binding]
    public class NewPatientRegistrationSteps
    {
        private ActionResult _result;

        [Given(@"user provides First Name as ""(.*)""")]
        public void GivenUserProvidesFirstNameAs(string firstName)
        {
            if (!ScenarioContext.Current.ContainsKey("FirstName"))
            {
                ScenarioContext.Current.Add("FirstName", firstName);
            }
            else
            {
                ScenarioContext.Current["FirstName"] = firstName;
            }
        }

        [Given(@"user provides Last Name as ""(.*)""")]
        public void GivenUserProvidesLastNameAs(string lastName)
        {
            if (!ScenarioContext.Current.ContainsKey("LastName"))
            {
                ScenarioContext.Current.Add("LastName", lastName);
            }
            else
            {
                ScenarioContext.Current["LastName"] = lastName;
            }
        }

        [Given(@"user provides Member Id as ""(.*)""")]
        public void GivenUserProvidesMemberIdAs(string memberId)
        {
            ScenarioContext.Current.Add("MemberId", memberId);
        }

        [When(@"User Calls NewPatientRegistration method")]
        public void WhenUserCallsNewPatientRegistrationMethod()
        {

            PatientController con = new PatientController();
            Common.Patient patient = new Common.Patient()
            {
                FirstName = Convert.ToString((ScenarioContext.Current["FirstName"])),
                LastName = Convert.ToString((ScenarioContext.Current["LastName"])),
                MemberId = Convert.ToString((ScenarioContext.Current["MemberId"]))
            };
            _result = con.Create(patient);

        }

        [Then(@"NewPatientRegistration is successful")]
        public void ThenNewPatientRegistrationIsSuccessful()
        {
            var result = _result as RedirectToActionResult;
            var actionName = result.ActionName;
            Assert.AreEqual("Index", actionName.ToString());
        }
    }
}
