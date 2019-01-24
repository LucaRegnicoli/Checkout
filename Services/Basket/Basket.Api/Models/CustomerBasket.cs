using System.Collections.Generic;

namespace Checkout.Basket.Api.Models
{
    public class CustomerBasket
    {
        public string CustomerId { get; set; }

        public List<BasketItem> Items { get; set; }

        public CustomerBasket(string customerId)
        {
            CustomerId = customerId;
            Items = new List<BasketItem>();
        }
    }
}
