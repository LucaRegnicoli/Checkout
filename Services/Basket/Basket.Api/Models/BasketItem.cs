using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Basket.Api.Models
{
    public class BasketItem : IValidatableObject
    {
        // The class for this initial PoC is not easily extensible, 
        // to add more customisations we could introduce a generic type and/or a list of key/values pair, 
        // in order to allow the customers to personalise the schema

        public string Id { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public string PictureUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Quantity < 1)
            {
                results.Add(new ValidationResult("Invalid number of units", new[] { "Quantity" }));
            }

            return results;
        }
    }
}
