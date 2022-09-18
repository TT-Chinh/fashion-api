using FASHION.API.Models;
using FASHION.API.Reponsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FASHION.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> logger)
        {
            this.logger = logger;
        }

        [HttpPost("SignIn")]
        public IEnumerable<UserModel> SignIn(UserLogin data)
        {
            try
            {
                IUserReponsitory reponsitory = new UserReponsitory();
                return reponsitory.SignIn(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        [HttpGet("GetUserInfor")]
        public UserInfor GetUserInfor(int id)
        {
            try
            {
                IUserReponsitory reponsitory = new UserReponsitory();
                return reponsitory.GetUserInfor(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        [HttpGet("SumUserOrder")]
        public void SumUserOrder()
        {
            try
            {
                IUserReponsitory reponsitory = new UserReponsitory();
                reponsitory.SumUserOrder();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}