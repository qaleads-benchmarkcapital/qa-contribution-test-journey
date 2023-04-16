using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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

        public void EnterEmailAddress(string email)
        {
            EnterText(_emailLocator, email);
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

        public void ClearName()
        {
            var nameField = Driver.GetClickableElement(By.XPath(_nameLocator));
            nameField.Clear();
        }

        public void EnterName(string name)
        {
            EnterText(_nameLocator, name);
        }

        public void EnterPhone(string phoneNumber)
        {
            EnterText(_phoneLocator, phoneNumber);
        }

        public void EnterSubject(string subject)
        {
            EnterText(_subjectLocator, subject);
        }

        public void EnterMessage(string message)
        {
            EnterText(_messageLocator, message);
        }

        private void EnterText(string locator, string text)
        {
            var field = Driver.GetClickableElement(By.XPath(locator));
            field.Clear();
            field.SendKeys(text);
        }

        public void EnterSubject(int size)
        {
            var email = Faker.Lorem.Paragraph().Substring(0, size);
            EnterSubject(email);
        }

        public void EnterMessage(int size)
        {
            var email = Faker.Lorem.Sentence(size).Substring(0, size);
             EnterMessage(email);
        }
    }
}
