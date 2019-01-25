using Desktop.Client;
using Desktop.Client.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Desktop.FunctionalTests
{
    public class ShoppingScenarios
    {
        public Uri Url { get; set; } = new Uri("http://localhost:5201");

        [Fact]
        public async Task AddBasketItemAsync_Returns_Ok()
        {
            // Arrange
            var data = new AddBasketItemRequest()
            {
                BasketId = "Customer00",
                CatalogItemId = 10,
                Quantity = 5
            };
            var controller = new ShoppingController()
            {
                Url = Url
            };

            // Act
            await controller.AddBasketItemAsync(data);

            // Assert - Just check that an exception has not been thrown
        }

    }
}
