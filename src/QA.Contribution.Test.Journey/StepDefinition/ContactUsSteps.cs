using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.Contribution.Test.Journey.Page;
using Faker;
using Google.Protobuf.WellKnownTypes;

namespace QA.Contribution.Test.Journey.StepDefinition
{
    [Binding]
    public class ContactUsSteps
    {
        private Landing _landingPage;
        private ContactUs _contactUsPage;

        private string _blankPhoneNumber;

        public ContactUsSteps(ScenarioContext scenarioContext)
        {
            _landingPage = new Landing(scenarioContext);
            _contactUsPage = new ContactUs(scenarioContext);
            _blankPhoneNumber = string.Empty;
        }

        [Given("the Contact Us page is displayed")]
        public void GivenTheContactUsPageIsDisplayed()
        {
            _landingPage.Navigate();
        }

        [When("the customer types an empty string into the phone number field")]
        public void WhenTheCustomerEntersBasicMessageBlankPhoneNumber()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.EnterBlankPhone();
            _contactUsPage.EnterSubject();
            _contactUsPage.EnterMessage();
        }

        [When("the customer types a short string into the phone number field")]
        public void WhenTheCustomerEntersBasicMessageShortPhoneNumber()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.EnterShortPhone();
            _contactUsPage.EnterSubject();
            _contactUsPage.EnterMessage();
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
            _contactUsPage.ClearEmailAddress();
        }
        
        [When("the user types a message into the message body field")]
        public void WhenTheUserTypesThisIsAMessageIntoTheMessageBodyField()
        {
            _contactUsPage.EnterMessage();
        }

        [Then("the message is successfully submitted")]
        public void ThenTheMessageIsSuccessfullySubmitted()
        {
            var message = _contactUsPage.GetSuccessMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }
        
        [Then("the message is not submitted successfully")]
        public void ThenTheMessageIsNotSubmittedSuccessfully()
        {
            var message = _contactUsPage.GetErrorMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }

        [Then("the customer is informed of the phone validation error")]
        public void ThenTheCustomerIsInformedOfTheBlankPhoneValidationError()
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
        
        [Then("the user is presented with the correct validation message")]
        public void ThenTheUserIsPresentedWithTheCorrectValidationMessage()
        {
            var message = _contactUsPage.GetErrorMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }

        [When(@"the customer completes a Basic Message with a malformed email address")]
        public void WhenTheCustomerCompletesATechincalSupportRequestWithAMalformedEmailAddress()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterInvalidEmailAddress();
            _contactUsPage.EnterPhone();
            _contactUsPage.EnterSubject();
            _contactUsPage.EnterMessage();
            _contactUsPage.EnterMessage();
        }
    }
}
