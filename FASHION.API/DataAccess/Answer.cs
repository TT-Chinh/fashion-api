using System;
using System.Collections.Generic;

#nullable disable

namespace FASHION.API.DataAccess
{
    public partial class Answer
    {
        public Answer()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Contents { get; set; }
        public string Action { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
