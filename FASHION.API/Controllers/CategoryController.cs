using FASHION.API.DataAccess;
using FASHION.API.Reponsitories;
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
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("GetAllCategories")]
        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                ICategoryReponsitory categoryReponsitory = new CategoryReponsitory();
                return categoryReponsitory.GetCategories();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
