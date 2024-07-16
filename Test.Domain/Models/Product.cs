using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Models
{
    public class Product
    {
        public int productId { get; set; }  

        public string Name { get; set; }   

        public decimal Price { get; set; } 

        public int  CateegoryId { get; set; }
    }
}
