using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.Contribution.Test.Journey.Page;
using System.Collections.Generic;
using QA.Contribution.Test.Journey.Validator;

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

        #region Name Validation

        [When(@"the customer completes a Basic Message with an empty Name")]
        public void WhenTheCustomerCompletesABasicMessageWithAnEmptyName()
        {
            //assign
            var rules = new List<ValidationRule>
            {
                new ValidationRule { Name = "name", HasValue = false, minLength = null, maxLength = null },//empty name
                new ValidationRule { Name = "email", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "phone", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "subject", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "message", HasValue = true, minLength = null, maxLength = null }
            };

            _contactUsPage.FillContactForm(rules);
        }

        [Then(@"the customer is presented with the Blank Name validation message")]
        public void ThenTheCustomerIsPresentedWithTheBlankNameValidationMessage()
        {
            var message = _contactUsPage.GetFieldValue("error");
            Assert.IsTrue(message.Contains("Name may not be blank"));
        }

        //Manual
        [When(@"the customer completes a Basic Message with only numeric or special characters as a Name")]
        public void WhenTheCustomerCompletesABasicMessageWithOnlyNumericOrSpecialCharactersAsAName()
        {
            throw new PendingStepException();
        }
        //Manual
        [Then(@"the customer is presented with the Invalid Name validation message")]
        public void ThenTheCustomerIsPresentedWithTheInvalidNameValidationMessage()
        {
            throw new PendingStepException();
        }

        #endregion

        #region Email Validation

        [When(@"the customer completes a Basic Message with an empty Email Address")]
        public void WhenTheCustomerCompletesABasicMessageWithAnEmptyEmailAddress()
        {
            //assign
            var rules = new List<ValidationRule>
            {
                new ValidationRule { Name = "name", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "email", HasValue = false, minLength = null, maxLength = null },
                new ValidationRule { Name = "phone", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "subject", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "message", HasValue = true, minLength = null, maxLength = null }
            };

            //act
            _contactUsPage.FillContactForm(rules);
        }

        [Then(@"the customer is presented with the Blank Email validation message")]
        public void ThenTheCustomerIsPresentedWithTheBlankEmailValidationMessage()
        {
            var message = _contactUsPage.GetFieldValue("error");
            Assert.IsTrue(message.Contains("Email may not be blank"));
        }

        [When(@"the customer completes a Basic Message with a malformed email (.*)")]
        public void WhenTheCustomerCompletesABasicMessageWithAMalformedEmail(string malformed_email_address)
        {
            _contactUsPage.EnterName();
            _contactUsPage.EnterIMalformedEmailAddress(malformed_email_address);
            _contactUsPage.EnterPhone();
            _contactUsPage.EnterSubject();
            _contactUsPage.EnterMessage();
        }

        [Then(@"the customer is presented with the Malformed Email validation message")]
        public void ThenTheCustomerIsPresentedWithTheMalformedEmailValidationMessage()
        {
            var message = _contactUsPage.GetFieldValue("error");
            Assert.IsTrue(message.Contains("must be a well-formed email address"));
        }

        #endregion

        #region Phone number validation

        [When(@"the customer completes a Basic Message with a Phone Number with less than minimum number of characters")]
        public void WhenTheCustomerCompletesABasicMessageWithAPhoneNumberWithLessThanMinimumNumberOfCharacters()
        {
            //assign
            var rules = new List<ValidationRule>
            {
                new ValidationRule { Name = "name", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "email", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "phone", HasValue = true, minLength = 10, maxLength = null },
                new ValidationRule { Name = "subject", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "message", HasValue = true, minLength = null, maxLength = null }
            };

            //act
            _contactUsPage.FillContactForm(rules);
        }

        [Then(@"the customer is presented with the Incorrect Phone Number Length validation message")]
        public void ThenTheCustomerIsPresentedWithTheIncorrectPhoneNumberLengthValidationMessage()
        {
            var message = _contactUsPage.GetFieldValue("error");
            Assert.IsTrue(message.Contains("Phone must be between 11 and 21 characters"));
        }

        #endregion

        #region Subject Validation

        [When(@"the customer completes a Basic Message with an empty subject")]
        public void WhenTheCustomerCompletesABasicMessageWithAnEmptySubject()
        {
            //assign
            var rules = new List<ValidationRule>
            {
                new ValidationRule { Name = "name", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "email", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "phone", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "subject", HasValue = false, minLength = null, maxLength = null },//empty subject
                new ValidationRule { Name = "message", HasValue = true, minLength = null, maxLength = null }
            };

            //act
            _contactUsPage.FillContactForm(rules);
        }

        [Then(@"the customer is presented with the Blank Subject validation message")]
        public void ThenTheCustomerIsPresentedWithTheBlankSubjectValidationMessage()
        {
            //assert
            var message = _contactUsPage.GetFieldValue("error");
            Assert.IsTrue(message.Contains("Subject may not be blank"));
        }

        [When(@"the customer completes a Basic Message with a Subject with less than minimum number of characters")]
        public void WhenTheCustomerCompletesABasicMessageWithASubjectWithLessThanMinimumNumberOfCharacters()
        {
            //assign
            var rules = new List<ValidationRule>
            {
                new ValidationRule { Name = "name", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "email", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "phone", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "subject", HasValue = true, minLength = 4, maxLength = null },
                new ValidationRule { Name = "message", HasValue = true, minLength = null, maxLength = null }
            };

            //act
            _contactUsPage.FillContactForm(rules);
        }

        [Then(@"the customer is presented with the Incorrect Subject Length validation message")]
        public void ThenTheCustomerIsPresentedWithTheIncorrectSubjectLengthValidationMessage()
        {
            var message = _contactUsPage.GetFieldValue("error");
            Assert.IsTrue(message.Contains("Subject must be between 5 and 100 characters"));
        }

        #endregion

        #region Message Validation

        [When(@"the customer completes a Basic Message with an empty Message Text")]
        public void WhenTheCustomerCompletesABasicMessageWithAnEmptyMessageText()
        {
            //assign
            var rules = new List<ValidationRule>
            {
                new ValidationRule { Name = "name", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "email", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "phone", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "subject", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "message", HasValue = false, minLength = null, maxLength = null }
            };

            //act
            _contactUsPage.FillContactForm(rules);
        }

        [Then(@"the customer is presented with the Blank Message validation message")]
        public void ThenTheCustomerIsPresentedWithTheBlankMessageValidationMessage()
        {
            var message = _contactUsPage.GetFieldValue("error");
            Assert.IsTrue(message.Contains("Message may not be blank"));
        }

        [When(@"the customer completes a Basic Message with a Message with less than minimum number of characters")]
        public void WhenTheCustomerCompletesABasicMessageWithAMessageWithLessThanMinimumNumberOfCharacters()
        {
            //assign
            var rules = new List<ValidationRule>
            {
                new ValidationRule { Name = "name", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "email", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "phone", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "subject", HasValue = true, minLength = null, maxLength = null },
                new ValidationRule { Name = "message", HasValue = true, minLength = 19, maxLength = null }
            };

            //act
            _contactUsPage.FillContactForm(rules);
        }

        [Then(@"the customer is presented with the Incorrect Message Length validation message")]
        public void ThenTheCustomerIsPresentedWithTheIncorrectMessageLengthValidationMessage()
        {
            var message = _contactUsPage.GetFieldValue("error");
            Assert.IsTrue(message.Contains("Message must be between 20 and 2000 characters"));
        }

        #endregion

        #region Existing Code

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

        [Then("the message is successfully submitted")]
        public void ThenTheMessageIsSuccessfullySubmitted()
        {
            var message = _contactUsPage.GetSuccessMessage();
            Assert.IsFalse(string.IsNullOrEmpty(message));
        }

        #endregion
    }
}