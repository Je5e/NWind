using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
   public class Products
    {
        // Crear un nuevo registro en la bd.
        public Product Create(Product newProduct)
        {
            Product Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Buscar si el nombre de producto existe
                Product res =
                    r.Retrieve<Product>(
                        p => p.ProductName == newProduct.ProductName);
            }
            return Result;
        }
    }
}
