using System;
using System.Collections.Generic;

#nullable disable

namespace FASHION.API.DataAccess
{
    public partial class Size
    {
        public Size()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public string Size1 { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
