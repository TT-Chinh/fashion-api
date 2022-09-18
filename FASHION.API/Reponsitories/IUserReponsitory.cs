using FASHION.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FASHION.API.Reponsitories
{
    public interface IUserReponsitory
    {
        IList<UserModel> SignIn(UserLogin data);
        UserInfor GetUserInfor(int id);
        public void SumUserOrder();
    }
}
