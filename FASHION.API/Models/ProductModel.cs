using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FASHION.API.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Discount { get; set; }
        public string Image { get; set; }
    }
    public class ProductDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Discount { get; set; }
        public int PayCount { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public IList<string> Images { get; set; }
    }

    public class ProductData
    {
        public int? CategoryID { get; set; }
        public string Brand { get; set; }
        public string Search { get; set; }
        public int? Start { get; set; }
        public int? End { get; set; }
        public bool? Driect { get; set; }
    }

    public class ProductSearch
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
    }
}
