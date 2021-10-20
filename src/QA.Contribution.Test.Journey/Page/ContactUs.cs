using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace QA.Contribution.Test.Journey.Page
{
    public class ContactUs : PageBase
    {
        public ContactUs(ScenarioContext context) : base(context)
        {
        }

        private readonly string _emailLocator = "//*[@id='fileUpload']";
        private readonly string _subjectHeadingLocator = "//*[@id='id_contact']";
        private readonly string _orderRefrenceLocator = "//*[@id='id_order']";
        private readonly string _messageLocator = "//*[@id='message']";
        private readonly string _submitMessageLocator = "//*[@id='submitMessage']";
        private readonly string _errorLocator = "//*[@class='alert alert-danger']";
        private readonly string _successLocator = "//*[@class='alert alert-success']";

        public void Navigate()
        {
            Driver.Url = Configuration.Get()[ConfigurationConstants.BaseUrl];
            Driver.Navigate();
        }

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

        public string EnterOrderReference()
        {
            var orderReference = Faker.Lorem.GetFirstWord();
            var orderReferenceField = Driver.GetClickableElement(By.XPath(_orderRefrenceLocator));
            orderReferenceField.Clear();
            orderReferenceField.SendKeys(orderReference);
            return orderReference;
        }

        public string EnterMessage()
        {
            var message = Faker.Lorem.Paragraph();
            var messageField = Driver.GetClickableElement(By.XPath(_messageLocator));
            messageField.Clear();
            messageField.SendKeys(message);
            return message;
        }

        public void SelectSubjectHeading(string subjectHeading = "")
        {
            string[] subjects = {"Customer service", "Webmaster"};
 
            if (string.IsNullOrEmpty(subjectHeading))
            {
                subjectHeading = subjects[Faker.RandomNumber.Next(0, 1)];
            }

            var selectSubjectHeading = Driver.GetSelectElement(By.XPath(_subjectHeadingLocator));
            selectSubjectHeading.SelectByText(subjectHeading);
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
    }
}
