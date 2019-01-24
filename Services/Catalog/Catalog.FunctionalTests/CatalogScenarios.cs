using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.FunctionalTests
{
    public class CatalogScenarios : CatalogScenariosBase
    {
        [Fact]
        public async Task Get_CatalogItemById_Returns_Ok()
        {
            using (var server = CreateServer())
            {
                var response = await server
                    .CreateClient()
                    .GetAsync(Get.ItemById(10));

                response.EnsureSuccessStatusCode();
            }
        }

        [Fact]
        public async Task Get_CatalogItemById_Returns_BadRequest()
        {
            using (var server = CreateServer())
            {
                var response = await server
                    .CreateClient()
                    .GetAsync(Get.ItemById(int.MinValue));

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task Get_CatalogItemById_Returns_NotFound()
        {
            using (var server = CreateServer())
            {
                var response = await server
                    .CreateClient()
                    .GetAsync(Get.ItemById(int.MaxValue));

                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
        }

        [Fact]
        public async Task Get_CatalogItemByName_Returns_Ok()
        {
            using (var server = CreateServer())
            {
                var response = await server
                    .CreateClient()
                    .GetAsync(Get.ItemByName(".NET"));

                response.EnsureSuccessStatusCode();
            }
        }

    }
}
