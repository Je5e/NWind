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
        public bool DeleteProduct(int ID)
        {
            var BLL = new Products();
            var Result = BLL.Delete(ID);
            return Result;
        }
        [HttpGet]
        public List<Product> FilterProductsByCategoryID(int ID)
        {
            var BLL = new Products();
            var Result = BLL.FilterByCategoryID(ID);
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
        public bool UpdateProduct(Product productToUpdate)
        {
            var BLL = new Products();
            var Result = BLL.Update(productToUpdate);
            return Result;

        }
    }
}
