using Checkout.Catalog.Api.ViewModels;
using Checkout.Catalog.Api.Models;
using Checkout.Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Checkout.Catalog.Api;
using Microsoft.Extensions.Options;

namespace Catalog.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogRepository _repository;
        private readonly CatalogSettings _settings;

        public CatalogController(ICatalogRepository repository, IOptionsSnapshot<CatalogSettings> settings)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _settings = settings?.Value ?? new CatalogSettings();
        }

        // GET api/v1/[controller]/items/10
        [HttpGet]
        [Route("items/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CatalogItem), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CatalogItem>> ItemByIdAsync(int id)
        {
            if (id <= 0) return BadRequest();

            var item = await _repository.GetCatalogItem(id);

            if (item != null)
                return item;
            else
                return NotFound();
        }

        // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("items")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<CatalogItem>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<CatalogItem>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<PaginatedItemsViewModel<CatalogItem>>> ItemsAsync([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0, string ids = null)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var convertingIds = ids.Split(',').Select(id => (Ok: int.TryParse(id, out int x), Value: x));

                if (!convertingIds.All(nid => nid.Ok)) return BadRequest("ids value invalid. Must be comma-separated list of numbers");

                var convertedIds = convertingIds.Select(id => id.Value);

                var items = await _repository.GetCatalogItems(pageIndex, pageSize, convertedIds, out long count);

                return Ok(items);
            }


            var itemsOnPage = await _repository.GetCatalogItems(pageIndex, pageSize, ids?.Split(',').Select(int.Parse)?.ToList(), out long totalItems);

            return new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage);
        }

        // GET api/v1/[controller]/items/withname/samplename[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("items/withname/{name:minlength(1)}")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<CatalogItem>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginatedItemsViewModel<CatalogItem>>> ItemsWithNameAsync(string name, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var itemsOnPage = await _repository.GetCatalogItems(pageIndex, pageSize, name, out long totalItems);

            return new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage);
        }

        // GET api/v1/[controller]/items/type/1/brand[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("items/type/{catalogTypeId}/brand/{catalogBrandId:int?}")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<CatalogItem>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginatedItemsViewModel<CatalogItem>>> ItemsByTypeIdAndBrandIdAsync(int catalogTypeId, int? catalogBrandId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var itemsOnPage = await _repository.GetCatalogItems(pageIndex, pageSize, catalogBrandId, catalogTypeId, out long totalItems);

            return new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage);
        }

        // GET api/v1/[controller]/items/type/all/brand[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("items/type/all/brand/{catalogBrandId:int?}")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<CatalogItem>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginatedItemsViewModel<CatalogItem>>> ItemsByBrandIdAsync(int? catalogBrandId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var itemsOnPage = await _repository.GetCatalogItems(pageIndex, pageSize, catalogBrandId, out long totalItems);

            return new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage);
        }

        // GET api/v1/[controller]/catalogtypes
        [HttpGet]
        [Route("catalogtypes")]
        [ProducesResponseType(typeof(List<CatalogType>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CatalogType>>> CatalogTypesAsync()
        {
            return await _repository.GetTypes();
        }

        // GET api/v1/[controller]/catalogbrands
        [HttpGet]
        [Route("catalogbrands")]
        [ProducesResponseType(typeof(List<CatalogBrand>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CatalogBrand>>> CatalogBrandsAsync()
        {
            return await _repository.GetBrands();
        }

        // PUT api/v1/[controller]/items
        [Route("items")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public ActionResult UpdateProductAsync([FromBody]CatalogItem productToUpdate)
        {
            return BadRequest("Method not implemented");
        }

        // POST api/v1/[controller]/items
        [Route("items")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public ActionResult CreateProductAsync([FromBody]CatalogItem product)
        {
            return BadRequest("Method not implemented");
        }

        //DELETE api/v1/[controller]/id
        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult DeleteProductAsync(int id)
        {
            return BadRequest("Method not implemented");
        }
    }
}

