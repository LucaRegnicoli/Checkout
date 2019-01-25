using System.Net.Http;
using System.Threading.Tasks;
using Checkout.Desktop.Api.Config;
using Checkout.Desktop.Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Checkout.Desktop.Api.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BasketService> _logger;
        private readonly UrlsConfig _urls;

        public BasketService(HttpClient httpClient, ILogger<BasketService> logger, IOptions<UrlsConfig> config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _urls = config.Value;
        }

        public async Task<BasketData> GetByIdAsync(string id)
        {
            var data = await _httpClient.GetStringAsync(_urls.Basket + UrlsConfig.BasketOperations.GetItemById(id));
            var basket = !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<BasketData>(data) : null;

            return basket;
        }

        public async Task DeleteAsync(string id)
        {
            await _httpClient.DeleteAsync(_urls.Basket + UrlsConfig.BasketOperations.DeleteItemById(id));
        }

        public async Task UpdateAsync(BasketData currentBasket)
        {
            var basketContent = new StringContent(JsonConvert.SerializeObject(currentBasket), System.Text.Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(_urls.Basket + UrlsConfig.BasketOperations.UpdateBasket(), basketContent);
        }
    }
}
