using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkout.Catalog.Api.Models;

namespace Checkout.Catalog.Api.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private List<CatalogItem> CatalogItems { get; set; }
        private List<CatalogBrand> CatalogBrands { get; set; }
        private List<CatalogType> CatalogTypes { get; set; }

        public Task<List<CatalogType>> GetTypes()
        {
            if (CatalogTypes == null) CatalogTypes = GetPreconfiguredCatalogTypes();

            return Task.FromResult(CatalogTypes);
        }

        public Task<List<CatalogBrand>> GetBrands()
        {
            if (CatalogBrands == null) CatalogBrands = GetPreconfiguredCatalogBrands();

            return Task.FromResult(CatalogBrands);
        }

        public Task<CatalogItem> GetCatalogItem(int id)
        {
            if (CatalogItems == null) CatalogItems = GetPreconfiguredItems();

            return Task.FromResult(CatalogItems.FirstOrDefault(c => c.Id == id));
        }

        public Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, out long count) => GetCatalogItems(pageIndex, pageSize, null, null, null, out count);

        public Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, string name, out long count) => GetCatalogItems(pageIndex, pageSize, null, null, name, out count);

        public Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, int? brand, out long count) => GetCatalogItems(pageIndex, pageSize, brand, null, null, out count);

        public Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, int? brand, int? type, out long count) => GetCatalogItems(pageIndex, pageSize, brand, type, null, out count);

        public Task<List<CatalogItem>> GetCatalogItems(int pageIndex, int pageSize, int? brand, int? type, string name, out long count)
        {
            if (CatalogItems == null) CatalogItems = GetPreconfiguredItems();

            var items = CatalogItems.AsQueryable();

            if (brand.HasValue)
                items = items.Where(i => i.CatalogBrandId == brand);

            if (type.HasValue)
                items = items.Where(i => i.CatalogTypeId == type);

            if (!string.IsNullOrEmpty(name))
                items = items.Where(i => i.Name.Contains(name));

            count = items.Count();

            var list = items
                .OrderBy(i => i.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            return Task.FromResult(list);
        }

        private List<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand() { Brand = "Azure"},
                new CatalogBrand() { Brand = ".NET" },
                new CatalogBrand() { Brand = "Visual Studio" },
                new CatalogBrand() { Brand = "SQL Server" },
                new CatalogBrand() { Brand = "Other" }
            };
        }

        private List<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() { Type = "Mug"},
                new CatalogType() { Type = "T-Shirt" },
                new CatalogType() { Type = "Sheet" },
                new CatalogType() { Type = "USB Memory Stick" }
            };
        }

        private List<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem { Id = 10, CatalogTypeId = 2, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Bot Black Hoodie", Name = ".NET Bot Black Hoodie", Price = 19.5M, PictureFileName = "1.png" },
                new CatalogItem { Id = 15, CatalogTypeId = 1, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Black & White Mug", Name = ".NET Black & White Mug", Price= 8.50M, PictureFileName = "2.png" },
                new CatalogItem { Id = 20, CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Prism White T-Shirt", Name = "Prism White T-Shirt", Price = 12, PictureFileName = "3.png" },
                new CatalogItem { Id = 25, CatalogTypeId = 2, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Foundation T-shirt", Name = ".NET Foundation T-shirt", Price = 12, PictureFileName = "4.png" },
                new CatalogItem { Id = 30, CatalogTypeId = 3, CatalogBrandId = 5, AvailableStock = 100, Description = "Roslyn Red Sheet", Name = "Roslyn Red Sheet", Price = 8.5M, PictureFileName = "5.png" },
                new CatalogItem { Id = 35, CatalogTypeId = 2, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Blue Hoodie", Name = ".NET Blue Hoodie", Price = 12, PictureFileName = "6.png" },
                new CatalogItem { Id = 40, CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Roslyn Red T-Shirt", Name = "Roslyn Red T-Shirt", Price = 12, PictureFileName = "7.png" },
                new CatalogItem { Id = 45, CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Kudu Purple Hoodie", Name = "Kudu Purple Hoodie", Price = 8.5M, PictureFileName = "8.png" },
                new CatalogItem { Id = 50, CatalogTypeId = 1, CatalogBrandId = 5, AvailableStock = 100, Description = "Cup<T> White Mug", Name = "Cup<T> White Mug", Price = 12, PictureFileName = "9.png" },
                new CatalogItem { Id = 55, CatalogTypeId = 3, CatalogBrandId = 2, AvailableStock = 100, Description = ".NET Foundation Sheet", Name = ".NET Foundation Sheet", Price = 12, PictureFileName = "10.png" },
                new CatalogItem { Id = 60, CatalogTypeId = 3, CatalogBrandId = 2, AvailableStock = 100, Description = "Cup<T> Sheet", Name = "Cup<T> Sheet", Price = 8.5M, PictureFileName = "11.png" },
                new CatalogItem { Id = 65, CatalogTypeId = 2, CatalogBrandId = 5, AvailableStock = 100, Description = "Prism White TShirt", Name = "Prism White TShirt", Price = 12, PictureFileName = "12.png" },
            };
        }
    }
}
