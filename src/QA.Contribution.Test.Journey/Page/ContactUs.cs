using OpenQA.Selenium;
using QA.Contribution.Test.Journey.Validator;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace QA.Contribution.Test.Journey.Page
{
    public class ContactUs : PageBase
    {
        List<ValidationRule> _rules = new List<ValidationRule>();
        IDictionary<string, string> _elementLocators;
        public ContactUs(ScenarioContext context) : base(context)
        {
            _elementLocators = new Dictionary<string, string>
            {
                { "email", "//*[@id='email']" },
                { "message", "//*[@id='description']" },
                { "submit", "//*[@id='submitContact']" },
                { "subject", "//*[@id='subject']" },
                { "error", "//*[@class='alert alert-danger']" },
                { "success", "//*[text()='Thanks for getting in touch']" },
                { "name", "//*[@id='name']" },
                { "phone", "//*[@id='phone']" },
                { "successMessage", "//*[@class='col-sm-5']" }
            };
        }

        #region Existing Locators 
        private readonly string _emailLocator = "//*[@id='email']";
        private readonly string _messageLocator = "//*[@id='description']";
        private readonly string _submitMessageLocator = "//*[@id='submitContact']";
        private readonly string _subjectLocator = "//*[@id='subject']";
        private readonly string _errorLocator = "//*[@class='alert alert-danger']";
        private readonly string _successLocator = "//*[text()='as soon as possible.']";
        private readonly string _nameLocator = "//*[@id='name']";
        private readonly string _phoneLocator = "//*[@id='phone']";

        #endregion

        #region - Newly Added Reusable Methods
        public void FillContactForm(List<ValidationRule> rules)
        {
            foreach (ValidationRule rule in rules)
            {
                //check if field empty
                if (rule.HasValue && _elementLocators.ContainsKey(rule.Name))
                    SetFieldValue(rule.Name.Trim(), rule.minLength, rule.maxLength);
            }
        }

        public string GetFieldValue(string key)
        {
            string locator = _elementLocators[key];
            return Driver.GetClickableElement(By.XPath(locator)).Text;
        }

        public string SetFieldValue(string key, int? minLength, int? maxLength)
        {
            var fakeValue = string.Empty;
            string locator = _elementLocators[key];
            var element = Driver.GetClickableElement(By.XPath(locator));
            element.Clear();

            switch (key)
            {
                case "name":
                    fakeValue = Faker.Name.FullName();
                    break;

                case "email":
                    fakeValue = Faker.Internet.Email();
                    break;

                case "phone":
                    fakeValue = Faker.Phone.Number();
                    break;

                case "subject":
                    fakeValue = Faker.Lorem.GetFirstWord();
                    break;

                case "message":
                    fakeValue = Faker.Lorem.Paragraph();

                    break;
                default:
                    return fakeValue;
            }

            if (minLength != null && fakeValue.Length > minLength)
                fakeValue = fakeValue.Substring(0, (int)minLength);

            element.SendKeys(fakeValue);
            return fakeValue;
        }

        #endregion

        public string ClickSend()
        {
            Driver.GetClickableElement(By.XPath(_submitMessageLocator)).Click();
            return Driver.Url;
        }

        public string EnterEmailAddress()
        {
            var email = Faker.Internet.Email();
            var emailField = Driver.GetClickableElement(By.XPath(_emailLocator));
            emailField.Clear();
            emailField.SendKeys(email);
            return email;
        }

        public string EnterInvalidEmailAddress()
        {
            var email = Faker.Lorem.GetFirstWord();
            var emailField = Driver.GetClickableElement(By.XPath(_emailLocator));
            emailField.Clear();
            emailField.SendKeys(email);
            return email;
        }

        public string EnterIMalformedEmailAddress(string malformed_email_address)
        {
            var emailField = Driver.GetClickableElement(By.XPath(_emailLocator));
            emailField.Clear();
            emailField.SendKeys(malformed_email_address);
            return malformed_email_address;
        }

        public void ClearEmailAddress()
        {
            var emailField = Driver.GetClickableElement(By.XPath(_emailLocator));
            emailField.Clear();
        }

        public string EnterMessage()
        {
            var message = Faker.Lorem.Paragraph();
            var messageField = Driver.GetClickableElement(By.XPath(_messageLocator));
            messageField.Clear();
            messageField.SendKeys(message);
            return message;
        }

        public string GetErrorMessage()
        {
            var errorAlert = Driver.GetClickableElement(By.XPath(_errorLocator));
            return errorAlert.Text;
        }

        public string GetSuccessMessage()
        {
            var successAlert = Driver.GetClickableElement(By.XPath(_successLocator));
            return successAlert.Text;
        }

        public string EnterPhone()
        {
            var phoneNumber = Faker.Phone.Number();
            var phoneField = Driver.GetClickableElement(By.XPath(_phoneLocator));
            phoneField.Clear();
            phoneField.SendKeys(phoneNumber);
            return phoneNumber;
        }

        public string EnterName()
        {
            var name = Faker.Name.FullName();
            var nameField = Driver.GetClickableElement(By.XPath(_nameLocator));
            nameField.Clear();
            nameField.SendKeys(name);
            return name;
        }

        public string EnterSubject()
        {
            var name = Faker.Lorem.GetFirstWord();
            var nameField = Driver.GetClickableElement(By.XPath(_subjectLocator));
            nameField.Clear();
            nameField.SendKeys(name);
            return name;
        }
    }
}
