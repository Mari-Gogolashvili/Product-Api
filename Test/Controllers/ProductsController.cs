using Microsoft.AspNetCore.Mvc;
using Test.Domain.Models;
using Test.Services;
using Test.Services.Abstractions;
namespace Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _iProductService;

        public ProductsController(IProductService productService)
        {
            _iProductService = productService;
        }

        [HttpGet("GetProducts")]
        public List<Product> GetProducts()
        {
            return _iProductService.GetProducts();
        }

        [HttpGet("GetProductById")]

        public Product GetProductById(int id)
        {
            return _iProductService.GetProductById(id);
        }


        [HttpGet ("GetProductsByCategoryId")]

        public List<Product> GetProductsByCategoryId(int id)
        {
            return _iProductService.GetProductsByCategoryId (id);
        }

        [HttpGet("GetTotalPriceByCategoryId")]
        public decimal GetTotalPriceByCategoryId(int id)
        {
            return _iProductService.GetTotalPriceByCategoryId(id);
        }


        [HttpGet("GetTotalPriceOfProductFromEachCategory")]

        public List<decimal> GetTotalPriceOfProductFromEachCategory()
        {
            return _iProductService.GetTotalPriceOfProductFromEachCategory();
        }


        [HttpPost("AddProduct")]
        public Product AddBook(Product product)
        {
            return _iProductService.AddProduct(product);
        }

        [HttpPut("UpateProduct")]
        public Product UpdateBook(int id, Product product)
        {
            return _iProductService.UpdateProduct(id, product);
        }

        [HttpDelete("deleteProduct")]
        public Product DeleteBook(int id)
        {
            return _iProductService.DeleteProduct(id);
        }
    }
}
