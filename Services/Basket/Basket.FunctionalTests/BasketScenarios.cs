using Checkout.Basket.Api.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Basket.FunctionalTests
{
    public class BasketScenarios : BasketScenariosBase
    {
        [Fact]
        public async Task Get_BasketById_Returns_Ok()
        {
            using (var server = CreateServer())
            {
                var response = await server
                    .CreateClient()
                   .GetAsync(Get.GetBasket(1));

                response.EnsureSuccessStatusCode();
            }
        }

        [Fact]
        public async Task Post_Basket_Returns_Ok()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(GetFakeBasket(), UTF8Encoding.UTF8, "application/json");

                var response = await server
                    .CreateClient()
                    .PostAsync(Post.Basket, content);

                response.EnsureSuccessStatusCode();
            }
        }

        private string GetFakeBasket()
        {
            var order = new CustomerBasket("1");

            order.Items.Add(new BasketItem
            {
                ProductId = "1",
                ProductName = ".NET Bot Black Hoodie",
                UnitPrice = 10,
                Quantity = 1
            });

            return JsonConvert.SerializeObject(order);
        }
    }
}
