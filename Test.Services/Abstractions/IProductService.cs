using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Models;
namespace Test.Services.Abstractions
{
    public interface IProductService
    {
        public List<Product> GetProducts();
       
        public Product GetProductById(int id);

        public List<Product> GetProductsByCategoryId(int id);

        public decimal GetTotalPriceByCategoryId(int id);

        public List<decimal> GetTotalPriceOfProductFromEachCategory();

        public Product AddProduct(Product product);
        public Product UpdateProduct(int id , Product product);

        public Product DeleteProduct(int id);


    }
}
