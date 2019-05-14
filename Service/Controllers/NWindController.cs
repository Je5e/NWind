using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using BLL;
using SLC;

namespace Service.Controllers
{
    public class NWindController : ApiController, IService
    {
        [HttpPost]
        public Category CreateCategory(Category newCategory)
        {
            var BLL = new Categories();
            var NewCategory = BLL.Create(newCategory);
            return NewCategory;
        }

        [HttpPost]
        public Product CreateProduct(Product newProduct)
        {
            var BLL = new Products();
            var NewProduct = BLL.Create(newProduct);
            return NewProduct;
        }
        [HttpGet]
        public bool DeleteCategory(int ID)
        {
            var BLL = new Categories();
            var DeleteCategory = BLL.Delete(ID);
            return DeleteCategory;
        }
        [HttpGet]
        public bool DeleteProduct(int ID)

        {
            var BLL = new Products();
            var Result = BLL.Delete(ID);
            return Result;
        }
      
       [HttpGet]
        public List<Product> FilterProductsByCategoryID(int categoryID)
        {
            var BLL = new Products();
            var Result = BLL.FilterByCategoryID(categoryID);
            return Result;
        }
        [HttpGet]//DTO
        public List<Category> GetCategories()
        {
            var BLL = new Categories();
            var Result = BLL.GetCategories();
            return Result;
        }
        [HttpGet]
        public Category RetriveCategoryByID(int ID)
        {
            var BLL = new Categories();
            var Result = BLL.RetrieveByID(ID);
            return Result;
        }
        [HttpGet]
        public Product RetriveProductByID(int ID)
        {
            var BLL = new Products();
            var Result = BLL.RetrieveByID(ID);
            return Result;
        }
        [HttpPost]
        public bool UpdateCategory(Category categoryToUpdate)
        {
            var BLL = new Categories();
            var Result = BLL.Update(categoryToUpdate);
            return Result;
        }
        [HttpPost]
        public bool UpdateProduct(Product productToUpdate)
        {
            var BLL = new Products();
            var Result = BLL.Update(productToUpdate);
            return Result;
        }
        [HttpGet]
        public List<ProductCatDTO> GetList()
        {
            var BLL = new Categories();
            var BLLc = new Products();
            return BLL.GetCategories().
                Join(BLLc.Filter(), c => c.CategoryID, p => p.CategoryID, (c, p) => new ProductCatDTO { ProductID = p.ProductID, ProductName = p.ProductName, CategoryName = c.CategoryName }).ToList();
        }
    }

    public class ProductCatDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
}
