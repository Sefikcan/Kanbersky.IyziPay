using Microsoft.Extensions.Configuration;
using System.IO;

namespace Kanbersky.IyziPay.Core.Helpers
{
    public static class BaseHelpers
    {
        public static IConfigurationRoot GetConfigurationRoot(string[] args)
        {
            //Environment bazlı yapılabilir!
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", false, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }
    }
}
