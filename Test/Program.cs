using DAL;
using Entities;
using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //  AddProduct();
            //RetrieveAndUpdate();
            //List();
            AddCategoryAndProduct();
            //SearchAndDelete();
            Console.Write("Presione <enter> para finalizar");
            Console.ReadLine();
        }

        static void AddCategoryAndProduct()
        {
            Category c = new Category()
            {
                CategoryName = "Mariscos",
                Description = "Productos del mar"
            };

            Product Cereal = new Product
            { 
                ProductName = "Camaron",
                UnitsInStock = 0,
                UnitPrice = 15
            };
            c.Products.Add(Cereal);

            var p = new Product();
            
            
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


        static void List()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Buscar una category agregada previamente
                var Categories = r.Filter<Category>(c => true);

                //var Products = r.Filter<Product>
                //    (p => p.ProductName.Contains("ae"))
                //    .OrderByDescending(p=> p.ProductName);
                var Products = r.Filter<Product>(p => true);

                // Inne Join con Linq
                // T-SQL: DML(SELECT, INSERT, DELETE, UPDATE) ADO.NET
                //SqlConnection Cnn;
                //SqlCommand cmd;
                //SqlDataReader R;
                //string ConnectionString = "Data Source=.;Initial Catalog=NWind;Integrate Security=True";
                //Cnn = new SqlConnection(ConnectionString);

                //cmd = new SqlCommand("SELECT * FROM Categories");
                //cmd.Connection = Cnn;
                //Cnn.Open();
                //R = cmd.ExecuteReader();
                //while (R.Read())
                //{
                //    Category c = new Category();
                //    c.CategoryID = R.GetInt32(0);
                //    c.CategoryName = R.GetName(1);

                //    Categories.Add(c);
                //}
                //Cnn.Close();

                var ListProduct =
                    from prod in Products
                    join cate in Categories on prod.CategoryID
                    equals cate.CategoryID
                    select new
                    {
                        CategoryName = cate.CategoryName,
                        ProducName = prod.ProductName
                    };
                foreach (var P in ListProduct)
                {
                    Console.WriteLine($"{P.CategoryName}, {P.ProducName}");
                }
            }
        }

        static void SearchAndDelete() // Eliminarlo
        {
            using (var R = RepositoryFactory.CreateRepository())
            {
                var P = R.Retrieve<Product>(p => p.ProductID == 1);
                if (P != null)
                {
                    Console.WriteLine(P.ProductName);
                    R.Delete(P);
                    Console.WriteLine("Producto Eliminado!");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado!");
                }
               
            }
        }
    }
}
