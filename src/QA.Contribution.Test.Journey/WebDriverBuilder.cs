using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA.Contribution.Test.Journey
{
    public static class WebDriverBuilder
    {
        public static IWebDriver CreateNew()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(ChromemiumConstants.NoSandbox);
            chromeOptions.AddArguments(ChromemiumConstants.DisableExtensions);
            chromeOptions.AddArguments(ChromemiumConstants.StartMaximized);
            chromeOptions.AddArguments(ChromemiumConstants.LanguageGb);
            chromeOptions.AddExcludedArgument(ChromemiumConstants.EnableAutomation);
            chromeOptions.AddAdditionalChromeOption(ChromemiumConstants.UseAutomationExtension, false);
            chromeOptions.AddUserProfilePreference(ChromemiumConstants.CredentialsEnableService, false);
            var driver = new ChromeDriver(Extensions.GetCurrentDirectory(), chromeOptions);
            return driver;
        }


    }
}
