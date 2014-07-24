using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ProductsApp.API.Model.Dtos;
using ProductsApp.API.Model.RequestModels;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Repositories;

namespace ProductsApp.API.Webhost.Controllers
{
    public class ProductsController : ApiController
    {
        static readonly IProductRepository _repository = new ProductRepository();

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _repository.GetAll()
                .Select(p => new ProductDto(p))
                .ToList();
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _repository.Get(id);
            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(new ProductDto(product));
        }

        public IEnumerable<ProductDto> GetProductsByCategory(string category)
        {
            var searchedProducts = _repository.GetAll()
                .Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return searchedProducts.Any()
                ? searchedProducts.Select(p => new ProductDto(p))
                : new List<ProductDto>();
        }

        public HttpResponseMessage PostProduct(ProductRequestModel item)
        {
            var entity = new Product();
            item.UpdateSource(entity);

            entity = _repository.Add(entity);
            var response = Request.CreateResponse<ProductDto>(HttpStatusCode.Created, new ProductDto(entity));

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutProduct(int id, ProductRequestModel product)
        {
            product.Id = id;
            var productEntity = new Product();

            product.UpdateSource(productEntity);

            if (!_repository.Update(productEntity))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        public void DeleteProduct(int id)
        {
            Product item = _repository.Get(id);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _repository.Remove(id);
        }
    }
}
