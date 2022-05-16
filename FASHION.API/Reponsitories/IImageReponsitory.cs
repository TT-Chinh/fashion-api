using FASHION.API.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FASHION.API.Reponsitories
{
    public interface IImageReponsitory
    {
        IList<Image> GetAllImages(int productID);
    }
}
