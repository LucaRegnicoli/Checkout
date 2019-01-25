using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Checkout.Desktop.Api.Config;
using Checkout.Desktop.Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Checkout.Desktop.Api.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CatalogService> _logger;
        private readonly UrlsConfig _urls;

        public CatalogService(HttpClient httpClient, ILogger<CatalogService> logger, IOptions<UrlsConfig> config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _urls = config.Value;
        }


        public async Task<CatalogItem> GetCatalogItemAsync(int id)
        {
            var stringContent = await _httpClient.GetStringAsync(_urls.Catalog + UrlsConfig.CatalogOperations.GetItemById(id));

            return JsonConvert.DeserializeObject<CatalogItem>(stringContent);
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(IEnumerable<int> ids)
        {
            var stringContent = await _httpClient.GetStringAsync(_urls.Catalog + UrlsConfig.CatalogOperations.GetItemsById(ids));

            return JsonConvert.DeserializeObject<CatalogItem[]>(stringContent);
        }
    }
}
