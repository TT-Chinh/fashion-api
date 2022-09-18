using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FASHION.API.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserInfor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
