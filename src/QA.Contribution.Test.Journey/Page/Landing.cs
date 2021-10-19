using TechTalk.SpecFlow;

using OpenQA.Selenium;

namespace QA.Contribution.Test.Journey.Page
{

    public class Landing : PageBase
    {
        public Landing(ScenarioContext context) : base(context)
        {
        }

        private readonly string _contactUsLocator = "//*[@id='contact-link']";

        public void Navigate()
        {
            Driver.Url = Configuration.Get()[ConfigurationConstants.BaseUrl];
            Driver.Navigate();
        }

        public string ClickContanctUs()
        {
            Driver.GetClickableElement(By.XPath(_contactUsLocator)).Click();
            return Driver.Url;
        }
    }
}
