﻿using System;
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

        [When("the customer completes a Basic Message with an invalid email address")]
        public void WhenTheCustomerTypesAnEmptyStringIntoTheEmailAddressField()
        {
            _contactUsPage.ClearEmailAddress();
            _contactUsPage.EnterMessage();
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
            _contactUsPage.EnterInvalidEmailAddress();
            _contactUsPage.EnterMessage();
        }

        [When(@"the customer completes an invalid message")]
        public void WhenTheCustomerCompletesAnInvalidMessage()
        {
            _contactUsPage.ClearMessage();
        }

        [When(@"the customer completes a Basic Message with an invalid phone number")]
        public void WhenTheCustomerCompletesATechnicalSupportRequestWithAnInvalidPhoneNumber()
        {
            _contactUsPage.ClearPhoneNumber();
        }

        [When(@"the customer completes a Basic Message with a malformed phone number")]
        public void WhenTheCustomerCompletesATechnicalSupportRequestWithAMalformedPhoneNumber()
        {
            _contactUsPage.ClearPhoneNumber();
            _contactUsPage.EnterMalformedPhone();
        }
    }
}
