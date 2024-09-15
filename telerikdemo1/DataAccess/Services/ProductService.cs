using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using telerikdemo1.DataAccess.Dto;

namespace telerikdemo1.DataAccess.Services
{
    public class ProductService
    {
        private HttpClient _http;

        private List<ProductDto> _products;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public Task<IEnumerable<ProductDto>> GetProducts()
        {
            return GetProductsInternal();
        }

        public void CreateProduct(ProductDto product)
        {
            if (!_products.Any())
            {
                product.ProductId = 1;
            }
            else
            {
                product.ProductId = _products.Max(p => p.ProductId) + 1;
            }

            _products.Insert(0, product);
        }

        public void UpdateProduct(ProductDto product)
        {
            var target = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (target != null)
            {
                target.ProductName = product.ProductName;
                target.SupplierId = product.SupplierId;
                target.CategoryId = product.CategoryId;
                target.CategoryName = product.CategoryName;
                target.QuantityPerUnit = product.QuantityPerUnit;
                target.UnitPrice = product.UnitPrice;
                target.UnitsInStock = product.UnitsInStock;
                target.UnitsOnOrder = product.UnitsOnOrder;
                target.ReorderLevel = product.ReorderLevel;
                target.Discontinued = product.Discontinued;
            }
        }

        public void DeleteProduct(ProductDto product)
        {
            var target = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (target != null)
            {
                _products.Remove(target);
            }
        }

        private async Task<IEnumerable<ProductDto>> GetProductsInternal()
        {
            if (_products == null)
            {
                _products  = (await _http.GetFromJsonAsync<IEnumerable<ProductDto>>("https://demos.telerik.com/blazor-ui-service/api/Product/GetProducts")).ToList();
            }

            return _products;
        }
    }
}