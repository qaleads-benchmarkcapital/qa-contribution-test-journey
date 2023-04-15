using OpenQA.Selenium;
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
        private readonly string _nameLocator = "//*[@id='name']";
        private readonly string _phoneLocator = "//*[@id='phone']";
        private readonly string _successMessageHeaderLocator = "//*[contains(text(),'Thanks for getting in touch')]";
        private readonly string _successSecondHeaderLocator = "//*[text()='We'll get back to you about']";
        private readonly string _successLastLocator = "//*[text()='as soon as possible.']";
        private readonly string _errorLocator = "//*[@class='alert alert-danger']";

        public string ClickSend()
        {
            Driver.GetClickableElement(By.XPath(_submitMessageLocator)).Click();
            return Driver.Url;
        }

        public string GetErrorMessage()
        {
            var errorAlert = Driver.GetClickableElement(By.XPath(_errorLocator));
            return errorAlert.Text;
        }

        public string GetSuccessMessageHeader()
        {
            var successAlert = Driver.GetClickableElement(By.XPath(_successMessageHeaderLocator));
            return successAlert.Text;
        }

        public string GetSuccessSecondHeaderLocator()
        {
            var successAlert = Driver.GetClickableElement(By.XPath(_successSecondHeaderLocator));
            return successAlert.Text;
        }

        public string GetSuccessLastLocator()
        {
            var successAlert = Driver.GetClickableElement(By.XPath(_successLastLocator));
            return successAlert.Text;
        }


        public string EnterEmailAddress()
        {
            var email = Faker.Internet.Email();
           EnterEmailAddress(email);
            return email;
        }

        public string EnterEmailAddress(string email)
        {
            var emailField = Driver.GetClickableElement(By.XPath(_emailLocator));
            Console.WriteLine("email f - "+emailField.Text);
            emailField.Clear();
            emailField.SendKeys(email);
            Console.WriteLine("email entered");
            return email;
        }

        public string EnterMalformedEmailAddress()
        {
            var email = Faker.Lorem.GetFirstWord();
            EnterEmailAddress(email);
            return email;
        }

        public void ClearEmailAddress()
        {
            var emailField = Driver.GetClickableElement(By.XPath(_emailLocator));
            emailField.Clear();
        }

        public void ClearNameField()
        {
            var nameField = Driver.GetClickableElement(By.XPath(_nameLocator));
            nameField.Clear();
        }

        public string EnterName()
        {
            var name = Faker.Name.FullName();
            EnterName(name);
            return name;
        }

        public string EnterName(string name)
        {
            var nameField = Driver.GetClickableElement(By.XPath(_nameLocator));
            nameField.Clear();
            nameField.SendKeys(name);
            return name;
        }

        public string EnterPhone()
        {
            var phoneNumber = Faker.Phone.Number();
            EnterPhone(phoneNumber);
            return phoneNumber;
        }

        public string EnterPhone(string phoneNumber)
        {
            var phoneField = Driver.GetClickableElement(By.XPath(_phoneLocator));
            phoneField.Clear();
            phoneField.SendKeys(phoneNumber);
            return phoneNumber;
        }

        public string EnterSubject()
        {
            var subject = Faker.Lorem.GetFirstWord();
            EnterSubject(subject);
            return subject;
        }

        public string EnterSubject(string subject)
        {
            var subjectField = Driver.GetClickableElement(By.XPath(_subjectLocator));
            subjectField.Clear();
            subjectField.SendKeys(subject);
            return subject;
        }

        public string EnterMessage()
        {
            var message = Faker.Lorem.Paragraph();
            EnterMessage(message);
            return message;
        }

        public string EnterMessage(string message)
        {
            var messageField = Driver.GetClickableElement(By.XPath(_messageLocator));
            messageField.Clear();
            messageField.SendKeys(message);
            return message;
        }
    }
}
