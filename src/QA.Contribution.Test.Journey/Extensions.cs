using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QA.Contribution.Test.Journey
{
    public static class Extensions
    {
        public static ConfigurationBuilder GetCurrentDirectory(this ConfigurationBuilder configurationBuilder, out string currentDirectory)
        {
            currentDirectory = GetCurrentDirectory();
            return configurationBuilder;
        }

        public static string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        }

        public static void AppendReport(this Exception exception, string message)
        {
            Console.WriteLine($"{message} /n Exception thrown: {exception}");
        }

        public static void AppendReport(this string message)
        {
            Console.WriteLine(message);
        }

        public static IWebElement GetClickableElement(this IWebDriver driver, By by)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(120))
            .Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static SelectElement GetSelectElement(this IWebDriver driver, By by)
        {
            return new SelectElement(driver.FindElement(by));
        }
    }
}
