using FASHION.API.DataAccess;
using FASHION.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FASHION.API.Reponsitories
{
    public interface IProductReponsitory
    {
        IList<ProductModel> GetAllProducts(ProductData data);
        IList<ProductModel> GetProductsPayCountMost();
        IList<ProductModel> GetProductsMostRelevant(int categoryID, string brand = null);
        ProductDetails GetProductDetails(int id);
        Product GetProduct(string name);
        IList<string> GetAllBrands();
    }
}
