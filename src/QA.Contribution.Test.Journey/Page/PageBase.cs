using OpenQA.Selenium;

using Reqnroll;

namespace QA.Contribution.Test.Journey.Page
{
    public abstract class PageBase
    {
        protected PageBase(ScenarioContext context)
        {
            Context = context;
        }

        protected IWebDriver Driver => Context.Get<IWebDriver>(ScenarioContextConstants.WebDriver);

        protected ScenarioContext Context;
    }
}
