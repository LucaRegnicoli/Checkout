using Checkout.Basket.Api.Models;
using Checkout.Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Checkout.Basket.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerBasket>> GetBasketByIdAsync(string id)
        {
            return await _repository.GetBasketAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerBasket), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerBasket>> UpdateBasketAsync([FromBody]CustomerBasket value)
        {
            return await _repository.UpdateBasketAsync(value);
        }

        [Route("checkout")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CheckoutAsync([FromBody]BasketCheckout basketCheckout)
        {
            var basket = await _repository.GetBasketAsync(basketCheckout.CustomerId);

            if (basket == null)
                return BadRequest();

            // Create the event message
            //var eventMessage = new UserCheckoutAccepted(basketCheckout.CustomerId, basketCheckout.City, basketCheckout.CardNumber, basketCheckout.CardHolderName ...);

            // Sends an integration event to payment.api to convert basket to an order and proceed with the payment
            //_eventBus.Publish(eventMessage);

            return Accepted();
        }

        // DELETE api/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task DeleteBasketByIdAsync(string id)
        {
            await _repository.DeleteBasketAsync(id);
        }
    }
}
