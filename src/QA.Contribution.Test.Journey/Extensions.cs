using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace QA.Contribution.Test.Journey
{
    public static class Extensions
    {
        public static ConfigurationBuilder GetCurrentDirectory(this ConfigurationBuilder configurationBuilder, out string currentDirectory)
        {
            currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            return configurationBuilder;
        }
    }
}
