using System;
using System.Collections.Generic;

#nullable disable

namespace FASHION.API.DataAccess
{
    public partial class Question
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public int AnswerId { get; set; }

        public virtual Answer Answer { get; set; }
    }
}
