namespace Checkout.Catalog.Api.Infrastructure.Filters
{
    internal class JsonErrorResponse
    {
        public string[] Messages { get; set; }

        public object DeveloperMeesage { get; set; }
    }
}
