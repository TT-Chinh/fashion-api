using FASHION.API.DataAccess;
using FASHION.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FASHION.API.Reponsitories
{
    public class ProductReponsitory : IProductReponsitory
    {
        public IList<ProductModel> GetAllProducts(ProductData data)
        {
            try
            {
                using (var model = new FASHIONBOTDBContext())
                {
                    var box = model.Products.ToList();
                    if(data.CategoryID != null)
                    {
                        box = box.Where(p => p.CategoryId == data.CategoryID).ToList();
                    }
                    if(data.Brand != null)
                    {
                        box = box.Where(p => !String.IsNullOrEmpty(p.Brand) && p.Brand.Contains(data.Brand)).ToList();
                    }
                    if (data.Search != null)
                    {
                        data.Search = data.Search.ToLower();
                        box = box.Where(p => p.Name.ToLower().Contains(data.Search)).ToList();
                    }

                    if (data.Start == null || data.Start < 0) data.Start = 0;
                    if (data.End == null || data.End < 0) data.End = 11;
                    if (data.Driect != null)
                    {
                        if (data.Driect == true)
                            box = box.OrderByDescending(p => p.Price).ToList();
                        else box = box.OrderBy(p => p.Price).ToList();
                    }

                    return box.Skip((int)data.Start).Take((int)(data.End - data.Start + 1)).Select(p => new ProductModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Discount = p.Discount,
                        Image = model.Images.Where(k => k.ProductId == p.Id && k.Indexs == 0).FirstOrDefault().FileName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public ProductDetails GetProductDetails(int id)
        {
            try
            {
                using(var model = new FASHIONBOTDBContext())
                {
                    ProductDetails p = null;
                    p = model.Products.Where(p => p.Id == id).Select(p => new ProductDetails
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Discount = p.Discount,
                        PayCount = p.PayCount,
                        Brand = p.Brand,
                        Category = p.Category.Name,
                        Images = p.Images.Select(m => m.FileName).ToList()
                    }).Single();
                    return p;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetProduct(string name)
        {
            try
            {
                var model = new FASHIONBOTDBContext();
                Product p = null;
                p = model.Products.Where(k => k.Name.ToLower().Contains(name.ToLower())).FirstOrDefault();
                return p;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<ProductModel> GetProductsPayCountMost()
        {
            try
            {
                using (var model = new FASHIONBOTDBContext())
                {
                    return model.Products.OrderByDescending(p => p.PayCount).Take(4).Select(p => new ProductModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Discount = p.Discount,
                        Image = model.Images.Where(k => k.ProductId == p.Id && k.Indexs == 0).FirstOrDefault().FileName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IList<ProductModel> GetProductsMostRelevant(int categoryID, string brand = null)
        {
            try
            {
                using (var model = new FASHIONBOTDBContext())
                {
                    return model.Products.Where(p => p.CategoryId == categoryID && (brand == null || p.Brand.Contains(brand))).OrderByDescending(p => p.Brand).Take(4).Select(p => new ProductModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Discount = p.Discount,
                        Image = model.Images.Where(k => k.ProductId == p.Id && k.Indexs == 0).FirstOrDefault().FileName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IList<string> GetAllBrands()
        {
            try
            {
                using (var model = new FASHIONBOTDBContext())
                {
                    var list = (from p in model.Products select p.Brand).Distinct().ToList();
                    return list;
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
