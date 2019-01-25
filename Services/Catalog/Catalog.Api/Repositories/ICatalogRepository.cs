using Checkout.Catalog.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Checkout.Catalog.Api.Repositories
{
    public interface ICatalogRepository
    {
        Task<CatalogItem> GetCatalogItem(int id);

        Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, IEnumerable<int> ids, out long count);

        Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, string name, out long count);

        Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, int? brand, out long count);

        Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, int? brand, int? type, out long count);

        Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, int? brand, int? type, string name, out long count);

        Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, int? brand, int? type, string name, IEnumerable<int> ids, out long count);

        Task<List<CatalogBrand>> GetBrands();

        Task<List<CatalogType>> GetTypes();
    }
}
