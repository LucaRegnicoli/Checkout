using Desktop.Client.Models;
using Microsoft.Rest;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Desktop.Client
{
    public class ShoppingController
    {
        //TODO: Add a configuration enum instead of address - for example: Staging/Production
        public Uri Url { get; set; } = new Uri("http://localhost:5201");
        
        public async Task AddBasketItemAsync(AddBasketItemRequest data, CancellationToken cancellationToken = default(CancellationToken))
        {
            var aggregator = new ShoppingAggregator(Url, null);

            await aggregator.ApiV1ShoppingItemsPostWithHttpMessagesAsync(data, null, cancellationToken);
        }

        public async Task<BasketData> UpdateQuantitiesAsync(UpdateBasketItemsRequest data, CancellationToken cancellationToken = default(CancellationToken))
        {
            var aggregator = new ShoppingAggregator(Url, null);

            var response = await aggregator.ApiV1ShoppingItemsPutWithHttpMessagesAsync(data, null, cancellationToken);

            return response.Body;
        }

        public async Task<BasketData> UpdateAllBasketAsync(UpdateBasketRequest data, CancellationToken cancellationToken = default(CancellationToken))
        {
            var aggregator = new ShoppingAggregator(Url, null);

            var response = await aggregator.ApiV1ShoppingPostWithHttpMessagesAsync(data, null , cancellationToken);

            return response.Body;
        }

        public async Task DeleteBasketAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var aggregator = new ShoppingAggregator(Url, null);

            await aggregator.ApiV1ShoppingByIdDeleteWithHttpMessagesAsync(id);
        }
    }
}
