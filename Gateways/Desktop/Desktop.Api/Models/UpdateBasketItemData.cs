namespace Checkout.Desktop.Api.Models
{
    public class UpdateBasketItemData
    {
        public string BasketItemId { get; set; }

        public int Quantity { get; set; }

        public UpdateBasketItemData()
        {
            Quantity = 0;
        }
    }
}
