using Basket.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;
using System.Reflection;

namespace Basket.FunctionalTests
{
    public class BasketScenariosBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(BasketScenariosBase)).Location;

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
            public static string GetBasket(int id) => $"api/v1/basket/{id}";
        }

        public static class Post
        {
            public static string Basket => $"api/v1/basket/";
        }
    }
}
