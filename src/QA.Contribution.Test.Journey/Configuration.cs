using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
namespace QA.Contribution.Test.Journey
{
    public static class Configuration
    {
        public static ReadOnlyDictionary<string, string> Get()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .GetCurrentDirectory(out string currentDirectory)
                .AddJsonFile($"{currentDirectory}/appSettings.json")
                .Build();
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add(ConfigurationConstants.BaseUrl, configuration[ConfigurationConstants.BaseUrl]);
            return new ReadOnlyDictionary<string, string>(dictionary);
        }
    }
}
