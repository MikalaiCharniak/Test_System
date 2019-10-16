using System;
using Microsoft.Extensions.Configuration;

namespace CW.TestSystem.CommonLogic.Environment
{
    public static class Settings
    {
        public static IConfiguration GetConfiguration() => new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
