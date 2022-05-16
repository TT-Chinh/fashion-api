using System;
using System.Collections.Generic;

#nullable disable

namespace FASHION.API.DataAccess
{
    public partial class BillDetail
    {
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size SizeNavigation { get; set; }
    }
}
