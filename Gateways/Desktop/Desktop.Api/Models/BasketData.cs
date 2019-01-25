using System.Collections.Generic;

namespace Checkout.Desktop.Api.Models
{
    public class BasketData
    {
        public string CustomerId { get; set; }

        public List<BasketDataItem> Items { get; set; }

        public BasketData(string customerId)
        {
            CustomerId = customerId;
            Items = new List<BasketDataItem>();
        }
    }
}
