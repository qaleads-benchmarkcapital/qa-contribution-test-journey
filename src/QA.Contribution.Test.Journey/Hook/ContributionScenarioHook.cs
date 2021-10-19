using System;

using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace QA.Contribution.Test.Journey.Hook
{
    [Binding]
    public class ContributionScenarioHook
    {
        private ScenarioContext _context;

        public ContributionScenarioHook(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenarioCreateWebDr()
        {
            try
            {
                _context.Set(WebDriverBuilder.CreateNew(), ScenarioContextConstants.WebDriver);
            }
            catch (Exception e)
            {
                e.AppendReport("Failed to create web driver.");
                throw;
            }
        }

        [AfterScenario(Order = 0)]
        public void QuitDriver()
        {
            try
            {
                _context.Get<IWebDriver>(ScenarioContextConstants.WebDriver).Quit();
            }
            catch (Exception e)
            {
                e.AppendReport("Failed to quit web driver.");
            }
        }

        [AfterScenario(Order = 1)]
        public void RemoveDriverFromContext()
        {
            try
            {
                _context.Remove(ScenarioContextConstants.WebDriver);
            }
            catch (Exception e)
            {
                e.AppendReport("Removing driver from context has failed.");
            }
        }
    }
}
