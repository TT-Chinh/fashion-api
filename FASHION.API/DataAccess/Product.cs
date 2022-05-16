using System;
using System.Collections.Generic;

#nullable disable

namespace FASHION.API.DataAccess
{
    public partial class Product
    {
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
            Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string ColorId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal? Price { get; set; }
        public int? Discount { get; set; }
        public int PayCount { get; set; }
        public bool IsDeleted { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Color Color { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
