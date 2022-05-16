using System;
using System.Collections.Generic;

#nullable disable

namespace FASHION.API.DataAccess
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
