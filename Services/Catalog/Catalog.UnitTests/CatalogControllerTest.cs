using Catalog.Api.Controllers;
using Checkout.Catalog.Api.Models;
using Checkout.Catalog.Api.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.UnitTests
{
    public class CatalogControllerTest
    {
        [Fact]
        public async void ItemByIdAsync_Returns_Success()
        {
            // Arrange
            var argumentId = 1;
            var expectedId = 1;
            var expectedName = "FakeItemA";
            var catalogServiceMock = new Mock<ICatalogRepository>();

            catalogServiceMock.Setup(x => x.GetCatalogItem
            (
                It.IsAny<int>()
             ))
             .Returns(Task.FromResult(GetFakeItem()));

            // Act
            var catalogController = new CatalogController(catalogServiceMock.Object, null);
            var actionResult = await catalogController.ItemByIdAsync(argumentId);

            // Assert
            Assert.NotNull(actionResult.Value);
            var model = Assert.IsAssignableFrom<CatalogItem>(actionResult.Value);
            Assert.Equal(expectedId, model.Id);
            Assert.Equal(expectedName, model.Name);
        }


        private CatalogItem GetFakeItem()
        {
            return new CatalogItem()
            {
                Id = 1,
                Name = "FakeItemA",
                CatalogTypeId = 1,
                CatalogBrandId = 2
            };
        }

    }
}
