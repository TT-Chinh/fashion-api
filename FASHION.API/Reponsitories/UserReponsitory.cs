using FASHION.API.DataAccess;
using FASHION.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FASHION.API.Reponsitories
{
    public class UserReponsitory : IUserReponsitory
    {
        public UserInfor GetUserInfor(int id)
        {
            try
            {
                using(var model = new FASHIONBOTDBContext())
                {
                    var user = model.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                        return new UserInfor
                        {
                            Id = user.Id,
                            FullName = user.FullName,
                            Email = user.Email,
                            Phone = user.Phone
                        };
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<UserModel> SignIn(UserLogin data)
        {
            try
            {
                using (var model = new FASHIONBOTDBContext())
                {
                    return model.Users.Where(u => (u.Email.Trim().Equals(data.Email) || u.Phone.Trim().Equals(data.Email)) && u.Password.Trim().Equals(data.Password) && !u.IsDeleted)
                        .Select(user => new UserModel
                        {
                            Id = user.Id,
                            FullName = user.FullName,
                            IsAdmin = user.UserRoles.First(r => r.UserId == user.Id).RoleId < 3
                        }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SumUserOrder()
        {
            try
            {
                using (var model = new FASHIONBOTDBContext())
                {
                    var list = from u in model.Users
                               select new
                               {
                                   Quy = ((u.CreatedDate.Month - 1) / 3) + 1,
                                   User = u
                               };

                    var result = from x in list
                                 group x by x.Quy
                                 into g
                                 select new
                                 {
                                     Quy = g.Key,
                                     Count = g.Count(),
                                     ListUsers = g
                                 };

                    foreach (var item in result)
                    {
                        Console.WriteLine($"Quy: {item.Quy} - Count: {item.Count}");
                        foreach (var x in item.ListUsers)
                        {
                            Console.WriteLine(x.User.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
