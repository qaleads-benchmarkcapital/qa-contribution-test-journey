using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.Contribution.Test.Journey.Page;
using TechTalk.SpecFlow.Assist;
using QA.Contribution.Test.Journey.Domain;

namespace QA.Contribution.Test.Journey.StepDefinition
{
    [Binding]
    public class ContactUsSteps
    {
        private Landing _landingPage;
        private ContactUs _contactUsPage;

        public ContactUsSteps(ScenarioContext scenarioContext)
        {
            _landingPage = new Landing(scenarioContext);
            _contactUsPage = new ContactUs(scenarioContext);
        }

        [Given("the Contact Us page is displayed")]
        public void GivenTheContactUsPageIsDisplayed()
        {
            _landingPage.Navigate();
        }

        [When("the customer enters a Basic Message")]
        public void WhenTheCustomerEntersBasicMessage()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.EnterPhone();
            _contactUsPage.EnterSubject();
            _contactUsPage.EnterMessage();
        }

        [When("the customer submits the message")]
        public void WhenTheCustomerSubmitsTheMessage()
        {
            _contactUsPage.ClickSend();
        }

        [When("the customer types an empty string into the email address field")]
        public void WhenTheCustomerTypesAnEmptyStringIntoTheEmailAddressField()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterPhone();
            _contactUsPage.EnterSubject();
            _contactUsPage.EnterMessage();
            _contactUsPage.ClearEmailAddress();
        }


        [When("the customer types an empty string into the name field")]
        public void WhenTheCustomerTypesAnEmptyStringIntoTheNameField()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterPhone();
            _contactUsPage.EnterSubject();
            _contactUsPage.EnterMessage();
            _contactUsPage.ClearEmailAddress();
            _contactUsPage.ClearNameField();
        }

        [When("the user types a message into the message body field")]
        public void WhenTheUserTypesThisIsAMessageIntoTheMessageBodyField()
        {
            _contactUsPage.EnterMessage();
        }

        [When(@"the customer types valid values in below fields:")]
        public void WhenTheCustomerTypesValidValuesInBelowFields(Table table)
        {
            var form = table.CreateInstance<ContactForm>();
            _contactUsPage.EnterName(form.name ?? string.Empty);
            Console.WriteLine("name entered");
            _contactUsPage.EnterPhone(form.phone ?? string.Empty);
            _contactUsPage.EnterSubject(form.subject ?? string.Empty);
            _contactUsPage.EnterMessage(form.message ?? string.Empty);
            _contactUsPage.EnterEmailAddress(form.email ?? string.Empty);
            Console.WriteLine("mail entered");
        }

        [When(@"the customer types malformed email address")]
        public void WhenTheCustomerTypesMalformedEmailAddress()
        {
            _contactUsPage.EnterMalformedEmailAddress();
        }

        [Then("the message is successfully submitted")]
        public void ThenTheMessageIsSuccessfullySubmitted()
        {
            var message = _contactUsPage.GetSuccessMessageHeader();
            Assert.IsFalse(string.IsNullOrEmpty(message));
            Assert.IsFalse(string.IsNullOrEmpty(_contactUsPage.GetSuccessMessageHeader()));
        }

        [Then("the message is not submitted successfully")]
        public void ThenTheMessageIsNotSubmittedSuccessfully()
        {
            var message = _contactUsPage.GetErrorMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }

        [Then("the customer is informed of the email validation error")]
        public void ThenTheCustomerIsInformedOfTheEmailValidationError()
        {
            var message = _contactUsPage.GetErrorMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }

        [Then(@"the customer is informed of ""(.*)"" error message")]
        public void ThenTheCustomerIsInformedOfErrorMessage(string errorMessage)
        {
            Console.WriteLine("*********** error - " + errorMessage);
            var message = _contactUsPage.GetErrorMessage();
            Assert.AreEqual(errorMessage, message);
        }

        [Then("the user is presented with the correct validation message")]
        public void ThenTheUserIsPresentedWithTheCorrectValidationMessage()
        {
            var message = _contactUsPage.GetErrorMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }
    }
}
