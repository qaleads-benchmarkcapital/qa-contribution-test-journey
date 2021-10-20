using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.Contribution.Test.Journey.Page;

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

        [Given(@"the Contact Us page is displayed")]
        public void GivenTheContactUsPageIsDisplayed()
        {
            var expectedUrl = "http://automationpractice.com/index.php?controller=contact";
            _landingPage.Navigate();
            var actualUrl = _landingPage.ClickContanctUs();
            Assert.AreEqual(expectedUrl, actualUrl);
        }
        
        [When(@"the customer enters a Basic Message intended for (.*)")]
        public void WhenTheCustomerEntersABasicMessageIntendedForCustomerServices(string subjectHeading)
        {
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.SelectSubjectHeading(subjectHeading);
            _contactUsPage.EnterMessage();
        }
        
        [When(@"the customer submits the message")]
        public void WhenTheCustomerSubmitsTheMessage()
        {
            _contactUsPage.ClickSend();
        }
        
        [When(@"the customer completes a Order Query message")]
        public void WhenTheCustomerCompletesAOrderQueryMessage()
        {
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.SelectSubjectHeading();
            _contactUsPage.EnterOrderReference();
            _contactUsPage.EnterMessage();
        }
        
        [When(@"the customer completes a Technical Support Request message")]
        public void WhenTheCustomerCompletesATechnicalSupportRequestMessage()
        {
            _contactUsPage.EnterEmailAddress();
            _contactUsPage.SelectSubjectHeading();
            _contactUsPage.EnterMessage();
        }
        
        [When(@"the customer types an empty string into the email address field")]
        public void WhenTheCustomerTypesAnEmptyStringIntoTheEmailAddressField()
        {
            _contactUsPage.ClearEmailAddress();
        }
        
        [When(@"the user types a message into the message body field")]
        public void WhenTheUserTypesThisIsAMessageIntoTheMessageBodyField()
        {
            _contactUsPage.EnterMessage();
        }
        
        [When(@"the user selects Webmaster in the Subject Heading field")]
        public void WhenTheUserSelectsWebmasterInTheSubjectHeadingField()
        {
            _contactUsPage.SelectSubjectHeading("Webmaster");
        }
        
        [When(@"the customer completes a Techincal Support Request with a malformed email address")]
        public void WhenTheCustomerCompletesATechincalSupportRequestWithAMalformedEmailAddress()
        {
            _contactUsPage.EnterInvalidEmailAddress();
            _contactUsPage.SelectSubjectHeading();
            _contactUsPage.EnterOrderReference();
            _contactUsPage.EnterMessage();
        }
        
        [Then(@"the message is successfully submitted")]
        public void ThenTheMessageIsSuccessfullySubmitted()
        {
            var message = _contactUsPage.GetSuccessMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }
        
        [Then(@"the message is not submitted successully")]
        public void ThenTheMessageIsNotSubmittedSuccessully()
        {
            var message = _contactUsPage.GetErrorMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }
        
        [Then(@"the customer is informed of the email validation error")]
        public void ThenTheCustomerIsInformedOfTheEmailValidationError()
        {
            var message = _contactUsPage.GetErrorMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }
        
        [Then(@"the user is presented with the correct validation message")]
        public void ThenTheUserIsPresentedWithTheCorrectValidationMessage()
        {
            var message = _contactUsPage.GetErrorMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }
    }
}
