using Checkout.Basket.Api.Controllers;
using Checkout.Basket.Api.Models;
using Checkout.Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Basket.UnitTests
{
    public class BasketControllerTest
    {
        [Fact]
        public async Task UpdateBasketAsync_Returns_Success()
        {
            // Arrange
            var argumentCustomerId = "1";
            var fakeCustomerBasket = GetCustomerBasketFake(argumentCustomerId);
            var basketRepositoryMock = new Mock<IBasketRepository>();

            basketRepositoryMock
                .Setup(x => x.UpdateBasketAsync
                (
                    It.IsAny<CustomerBasket>())
                )
                .Returns(Task.FromResult(fakeCustomerBasket));

            // Act
            var basketController = new BasketController(basketRepositoryMock.Object);
            var actionResult = await basketController.UpdateBasketAsync(fakeCustomerBasket);

            // Assert
            Assert.Equal(((CustomerBasket)actionResult.Value).CustomerId, argumentCustomerId);
        }

        private CustomerBasket GetCustomerBasketFake(string fakeCustomerId)
        {
            return new CustomerBasket(fakeCustomerId)
            {
                Items = new List<BasketItem>()
                {
                    new BasketItem()
                }
            };
        }
    }
}
