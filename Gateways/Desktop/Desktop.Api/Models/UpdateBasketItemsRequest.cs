using System.Collections.Generic;

namespace Checkout.Desktop.Api.Models
{
    public class UpdateBasketItemsRequest
    {
        public string BasketId { get; set; }

        public ICollection<UpdateBasketItemData> Updates { get; set; }

        public UpdateBasketItemsRequest()
        {
            Updates = new List<UpdateBasketItemData>();
        }
    }
}
