using Catalog.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;
using System.Reflection;

namespace Catalog.FunctionalTests
{
    public class CatalogScenariosBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(CatalogScenariosBase))
              .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                })
                .UseStartup<Startup>();

            return new TestServer(hostBuilder);
        }

        public static class Get
        {
            public static string ItemById(int id)
            {
                return $"api/v1/catalog/items/{id}";
            }

            public static string ItemByName(string name)
            {
                return $"api/v1/catalog/items/withname/{name}";
            }
        }
    }
}
