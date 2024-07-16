using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Models;
using Test.Services.Abstractions;
using Test.ProjectDb;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace Test.Services.Implementations
{
    public class ProductService : IProductService
    {

        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var productInDb = _dbContext.Products.FirstOrDefault(x => x.productId == id);
            if (productInDb == null) {
                
                 return null;
            }
            return productInDb;

        }




        public List<Product> GetProductsByCategoryId(int id)
        {
            var productInDb = _dbContext.Products.Where(x => x.CateegoryId == id).ToList();

            if(productInDb == null)
            {
                return null;
            }
            return productInDb;
        }




        public decimal GetTotalPriceByCategoryId(int id)
        {
           
           var productInDb = _dbContext.Products.Where(x => x.CateegoryId == id).Sum(x => x.Price);
           if (productInDb == null)
            {
                return 0;
            }
            return productInDb;
        }



        public List<decimal> GetTotalPriceOfProductFromEachCategory()
        {
            return _dbContext.Products.GroupBy(x => x.CateegoryId).Select(x => x.Sum(p => p.Price)).ToList();


            
        }



        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);

            _dbContext.SaveChanges();

            return product;
        }

        public Product UpdateProduct(int id, Product product)
        {
            var ProductInDb = _dbContext.Products.FirstOrDefault(x => x.productId == id);

            if (ProductInDb != null)
            {
                ProductInDb.Name = product.Name;
                ProductInDb.Price = product.Price;
                ProductInDb.CateegoryId = product.CateegoryId;
            }

            _dbContext.SaveChanges();

            return ProductInDb;
        }

        public Product DeleteProduct(int id)
        {
            var ProductInDb = _dbContext.Products.FirstOrDefault(x => x.productId == id);

            if (ProductInDb != null)
            {
                _dbContext.Products.Remove(ProductInDb);
            }

            _dbContext.SaveChanges();

            return ProductInDb;
        }
    }
}
