using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace SLC
{
   public interface IService
    {
        #region Operaciones con Products
        Product CreateProduct(Product newProduct);
        Product RetriveProductByID(int ID);
        bool UpdateProduct(Product productToUpdate);
        bool DeleteProduct(int ID);
        List<Product> FilterProductsByCategoryID(int categoryID);
        #endregion

        #region Operaciones con Categories
        Category CreateCategory(Category newCategory);
        Category RetriveCategoryByID(int ID);
        bool UpdateCategory(Category categoryToUpdate);
        bool DeleteCategory(int ID);
        List<Category> GetCategories();
        #endregion
    }
}
