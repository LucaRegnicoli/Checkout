namespace Checkout.Basket.Api.Infrastructure.Filters
{
    internal class JsonErrorResponse
    {
        public string[] Messages { get; set; }

        public object DeveloperMessage { get; set; }
    }
}