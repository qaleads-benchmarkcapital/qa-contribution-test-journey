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

        [When("the customer types an empty string into the phone number field")]
        public void WhenTheCustomerEntersBasicMessageBlankPhoneNumber()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.EnterPhone("blank");
            _contactUsPage.EnterSubject("valid");
            _contactUsPage.EnterMessage();
        }

        [When("the customer types a long string into the phone number field")]
        public void WhenTheCustomerEntersBasicMessageLongPhoneNumber()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.EnterPhone("long");
            _contactUsPage.EnterSubject("valid");
            _contactUsPage.EnterMessage();
        }

        [When("the customer types a short string into the phone number field")]
        public void WhenTheCustomerEntersBasicMessageShortPhoneNumber()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.EnterPhone("short");
            _contactUsPage.EnterSubject("valid");
            _contactUsPage.EnterMessage();
        }

        [When("the customer enters a Basic Message")]
        public void WhenTheCustomerEntersBasicMessage()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.EnterPhone("valid");
            _contactUsPage.EnterSubject("valid");
            _contactUsPage.EnterMessage();
        }

        [When("the customer types an empty string into the subject field")]
        public void WhenTheCustomerEntersBasicMessageEmptySubject()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.EnterPhone("valid");
            _contactUsPage.EnterSubject("blank");
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

        [Then("the customer is informed of the subject validation error")]
        public void ThenTheCustomerIsInformedOfThesubjectValidationError()
        {
            var message = _contactUsPage.GetErrorMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }

        [Then("the customer is informed of the phone validation error")]
        public void ThenTheCustomerIsInformedOfThePhoneValidationError()
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
        
        [Then("the customer is presented with the correct validation message")]
        public void ThenTheCustomerIsPresentedWithTheCorrectValidationMessage()
        {
            var message = _contactUsPage.GetErrorMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }

        [When(@"the customer completes a Basic Message with a malformed email address")]
        public void WhenTheCustomerCompletesATechincalSupportRequestWithAMalformedEmailAddress()
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterInvalidEmailAddress();
            _contactUsPage.EnterPhone("valid");
            _contactUsPage.EnterSubject("valid");
            _contactUsPage.EnterMessage();
        }
    }
}
