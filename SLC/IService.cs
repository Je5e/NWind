using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace SLC
{
   public interface IService
    {
        #region OPERACIONES CON Product
        Product CreateProduct(Product newProduct);
        Product RetriveProductByID(int ID);
        bool UpdateProduct(Product productToUpdate);
        bool DeleteProduct(int ID);
        List<Product> FilterProductsByCategoryID(int ID);
        #endregion

        #region Operaciones con Category
        Category CreateCategory(Category newCategory); 
        #endregion
    }
}
