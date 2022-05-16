using FASHION.API.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FASHION.API.Reponsitories
{
    public class CategoryReponsitory : ICategoryReponsitory
    {
        public IList<Category> GetCategories()
        {
            try
            {
                using(var model = new FASHIONBOTDBContext())
                {
                    return model.Categories.Where(c => c.Products.Count > 0).ToList();
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
