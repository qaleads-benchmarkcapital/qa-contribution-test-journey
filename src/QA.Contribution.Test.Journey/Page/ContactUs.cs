using OpenQA.Selenium;
using System;
using System.Text;
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

        private static Random random = new Random();


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

        public string EnterPhone(string type)
        {
            if (type == "valid")
            {
                var phoneNumber = Faker.Phone.Number();
                var phoneField = Driver.GetClickableElement(By.XPath(_phoneLocator));
                phoneField.Clear();
                phoneField.SendKeys(phoneNumber);
                return phoneNumber;
            }

            if (type == "blank")
            {
                var phoneNumber = string.Empty;
                var phoneField = Driver.GetClickableElement(By.XPath(_phoneLocator));
                phoneField.Clear();
                phoneField.SendKeys(phoneNumber);
                return phoneNumber;

            }

            if (type == "long")
            {
                var phoneNumber = GeneratePhoneNumber(23);
                var phoneField = Driver.GetClickableElement(By.XPath(_phoneLocator));
                phoneField.Clear();
                phoneField.SendKeys(phoneNumber);
                return phoneNumber; 
            }


            if (type == "short")
            {
                var phoneNumber = GeneratePhoneNumber(7);
                var phoneField = Driver.GetClickableElement(By.XPath(_phoneLocator));
                phoneField.Clear();
                phoneField.SendKeys(phoneNumber);
                return phoneNumber;
            }

            return null;

        }

        public string EnterName(string type)
        {
            if (type == "valid")
            {
                var name = Faker.Name.FullName();
                var nameField = Driver.GetClickableElement(By.XPath(_nameLocator));
                nameField.Clear();
                nameField.SendKeys(name);
                return name;
            }

            if (type == "blank")
            {
                var name = string.Empty;
                var nameField = Driver.GetClickableElement(By.XPath(_nameLocator));
                nameField.Clear();
                nameField.SendKeys(name);
                return name;
            }

            return null;

        }

        public string EnterSubject(string type)
        {
            if (type == "valid")
            {
                var subject = Faker.Lorem.GetFirstWord();
                var subjectField = Driver.GetClickableElement(By.XPath(_subjectLocator));
                subjectField.Clear();
                subjectField.SendKeys(subject);
                return subject;
            }

            if (type == "blank")
            {
                var subject = string.Empty;
                var subjectField = Driver.GetClickableElement(By.XPath(_subjectLocator));
                subjectField.Clear();
                subjectField.SendKeys(subject);
                return subject;
            }

            if (type == "short")
            {
                var subject = Faker.Lorem.GetFirstWord().Substring(0, 3);
                var subjectField = Driver.GetClickableElement(By.XPath(_subjectLocator));
                subjectField.Clear();
                subjectField.SendKeys(subject);
                return subject;
            }

            return null;


        }



        private static string GeneratePhoneNumber(int length)
        {
            StringBuilder phoneNumber = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                phoneNumber.Append(random.Next(0, 10));
            }

            return phoneNumber.ToString();
        }
    }
}
