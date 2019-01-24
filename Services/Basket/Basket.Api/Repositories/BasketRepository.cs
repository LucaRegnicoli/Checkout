using Checkout.Basket.Api.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ILogger<BasketRepository> _logger;
        private Dictionary<string, CustomerBasket> _baskets;

        public BasketRepository(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BasketRepository>();
            _baskets = new Dictionary<string, CustomerBasket>();
        }

        public Task<bool> DeleteBasketAsync(string customerId)
        {
            if (!_baskets.ContainsKey(customerId))
                return Task.FromResult(false);

            return Task.FromResult(_baskets.Remove(customerId));
        }

        public Task<CustomerBasket> GetBasketAsync(string customerId)
        {
            if (!_baskets.ContainsKey(customerId))
                return Task.FromResult(new CustomerBasket(customerId));

            return Task.FromResult(_baskets[customerId]);
        }

        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            _baskets[basket.CustomerId] = basket;

            return Task.FromResult(_baskets[basket.CustomerId]);
        }
    }
}
