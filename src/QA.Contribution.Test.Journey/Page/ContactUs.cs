using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using TechTalk.SpecFlow;

namespace QA.Contribution.Test.Journey.Page
{
    public class ContactUs : PageBase
    {
        public ContactUs(ScenarioContext context) : base(context)
        {
        }

        private readonly string _emailLocator = "//*[@id='email']";
        private readonly string _messageLocator = "//*[@id='description']";
        private readonly string _submitMessageLocator = "//*[@id='submitContact']";
        private readonly string _subjectLocator = "//*[@id='subject']";
        private readonly string _errorLocator = "//*[@class='alert alert-danger']";
        private readonly string _successLocator = "//*[text()='as soon as possible.']";
        private readonly string _nameLocator = "//*[@id='name']";
        private readonly string _phoneLocator = "//*[@id='phone']";
        private readonly string _nameErrorLocator = "//p[normalize-space()='Name may not be blank']";
        private readonly string _phoneErrorLocator = "//p[normalize-space()='Phone must be between 11 and 21 characters.']";
        private readonly string _subjectErrorLocator = "//p[normalize-space()='Subject must be between 5 and 100 characters.']";
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

        public void EnterEmptyName()
        {
            var nameField = Driver.GetClickableElement(By.XPath(_nameLocator));
            nameField.Clear();

        }

        public string GetNameErrorMessage()
        {
            var errorAlert = Driver.GetClickableElement(By.XPath(_nameErrorLocator));
            return errorAlert.Text;
        }

        public void EnterMinimumCharacterOfPhone()
        {
            var phone = Faker.Phone.Number();
            var shortPhone = phone.Trim().Length.ToString();
            var phoneField = Driver.GetClickableElement(By.XPath(_phoneLocator));
            phoneField.Clear();
            phoneField.SendKeys(shortPhone);
            
        }
        public string GetPhoneErrorMessage()
        {
            var errorAlert = Driver.GetClickableElement(By.XPath(_phoneErrorLocator));
            return errorAlert.Text;
        }
        public void EnterEmptyPhone()
        {
            var phoneField = Driver.GetClickableElement(By.XPath(_phoneLocator));
            phoneField.Clear();
        }
        public void  EnterEmptySubject()
        {
            var subjectField = Driver.GetClickableElement(By.XPath(_subjectLocator));
            subjectField.Clear();
        }
        public string GetSubjectErrorMessage()
        {
            var errorAlert = Driver.GetClickableElement(By.XPath(_subjectErrorLocator));
            return errorAlert.Text;
        }
        
    }
}
