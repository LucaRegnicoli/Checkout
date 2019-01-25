using Checkout.Desktop.Api.Models;
using System.Threading.Tasks;

namespace Checkout.Desktop.Api.Services
{
    public interface IBasketService
    {
        Task<BasketData> GetByIdAsync(string id);

        Task UpdateAsync(BasketData currentBasket);

        Task DeleteAsync(string id);
    }
}
