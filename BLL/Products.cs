using DAL;
using Entities;
using System.Collections.Generic;

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

                if (res == null)
                {
                    // No existe, podemos crearlo
                    Result = r.Create(newProduct);
                }
                else
                {
                    // TODO:
                    // Implementar una excepción pernalizada para ser lanzada?
                    //throw new System.Exception();
                    // Podríamos aquí lanzar una excepción
                    // para notificar que el producto ya existe.
                    // Podríamos incluso crear una capa de Excepciones
                    // Personalizadas y consumirla desde otras capas.
                }
            }
            return Result;
        }

        public Product RetrieveByID(int ID)
        {
            Product Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Retrieve<Product>(p => p.ProductID == ID);
            }
            return Result;
        }

        public bool Update(Product productToUpdate)
        {
            bool Result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Validar que el nombre de producto no exista.
                Product temp =
                    r.Retrieve<Product>
                    (p => p.ProductName == productToUpdate.ProductName
                    && p.ProductID != productToUpdate.ProductID);
                if (temp == null)
                {
                    // No existe
                    Result = r.Update(productToUpdate);
                }
                else
                {
                    // TODO:
                    // Podemos implementar una lógica para
                    // indicar que no se pudo modificar
                }
            }
            return Result;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            // Buscar el producto para ver si tiene existencias
            var Product = RetrieveByID(ID);
            if (Product != null)
            {
                if (Product.UnitsInStock == 0)
                {
                    // Eliminar el producto
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        Result = r.Delete(Product);
                    }
                }
                else
                {
                    // TODO:    
                    // Podemos implementar alguna lógica adicional
                    // para indicar que el producto no se pudo eliminar.
                }
            }
            else
            {
                // TODO:
                // El producto no existe
            }

            return Result;
        }

        public List<Product> FilterByCategoryID(int categoryID)
        {
            List<Product> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result =
                    r.Filter<Product>
                    (p => p.CategoryID == categoryID);
            }
            return Result;
        }
    }
}
