using FASHION.API.DataAccess;
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
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;

        public ProductController(ILogger<ProductController> logger)
        {
            this.logger = logger;
        }

        [HttpPost("GetAllProduct")]
        public IEnumerable<ProductModel> GetAllProduct(ProductData data)
        {
            try
            {
                IProductReponsitory productReponsitory = new ProductReponsitory();
                return productReponsitory.GetAllProducts(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetProductDetails")]
        public ProductDetails GetProductDetails(int id)
        {
            try
            {
                IProductReponsitory productReponsitory = new ProductReponsitory();
                return productReponsitory.GetProductDetails(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetProductsPayCountMost")]
        public IEnumerable<ProductModel> GetProductsPayCountMost()
        {
            try
            {
                IProductReponsitory productReponsitory = new ProductReponsitory();
                return productReponsitory.GetProductsPayCountMost();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetProductsMostRelevant")]
        public IEnumerable<ProductModel> GetProductsMostRelevant(int categoryID, string brand = null)
        {
            try
            {
                IProductReponsitory productReponsitory = new ProductReponsitory();
                return productReponsitory.GetProductsMostRelevant(categoryID, brand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetAllBrands")]
        public IEnumerable<string> GetAllBrands()
        {
            try
            {
                IProductReponsitory productReponsitory = new ProductReponsitory();
                return productReponsitory.GetAllBrands();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
