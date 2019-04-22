using DAL;
using Entities;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //  AddProduct();
            RetrieveAndUpdate();
            Console.Write("Presione <enter> para finalizar");
            Console.ReadLine();
        }

        static void AddCategoryAndProduct()
        {
            Category c = new Category()
            {
                CategoryName = "Cereales",
                Description = "Productos de maíz"
            };

            Product Cereal = new Product
            {
                ProductName = "Cereal",
                UnitsInStock = 0,
                UnitPrice = 15
            };
            c.Products.Add(Cereal);


            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(c);
            }
            Console.WriteLine($"Categoría:{c.CategoryID}, " +
                $"Producto:{Cereal.ProductID}");
        }

        static void AddProduct()
        {
            Product Avena = new Product
            {
                CategoryID = 1,
                UnitsInStock = 100,
                ProductName = "Avena",
                UnitPrice = 10
            };
            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(Avena);
            }
            Console.WriteLine($"Producto: {Avena.ProductID}");
        }

        // Buscar y modificación
        static void RetrieveAndUpdate()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Buscar el producto agregado
                Product P = r.Retrieve<Product>(p => p.ProductID == 2);
                if (P != null)
                {
                    Console.WriteLine(P.ProductName);
                    P.ProductName = P.ProductName + "#######";
                    r.Update(P);
                    Console.WriteLine("Nombre modificado");
                    
                }
            }
        }
    }
}
