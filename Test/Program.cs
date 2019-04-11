using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entities;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCategoryAndProduct();
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
                UnitsInStock=0,
                UnitPrice =15
            };
            c.Products.Add(Cereal);


            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(c);   
            }
            Console.WriteLine($"Categoría:{c.CategoryID}, " +
                $"Producto:{Cereal.ProductID}");
        }
    }
}
