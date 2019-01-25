using System.Collections.Generic;

namespace Checkout.Desktop.Api.Models
{
    public class UpdateBasketRequest
    {
        public string CustomerId { get; set; }

        public IEnumerable<UpdateBasketRequestItemData> Items { get; set; }
    }
}
