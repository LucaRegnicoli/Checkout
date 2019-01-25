using Checkout.Desktop.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Desktop.Api.Services
{
    public interface ICatalogService
    {
        Task<CatalogItem> GetCatalogItemAsync(int id);

        Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(IEnumerable<int> ids);
    }
}
