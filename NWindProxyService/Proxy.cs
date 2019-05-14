using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Net.Http.Headers;
using SLC;
using Newtonsoft.Json;

namespace NWindProxyService
{
    public class Proxy : IService
    {
        string BaseAddress = "http://localhost:52798/";

        public async Task<T> SendPost<T, PostData>
            (string requestURI, PostData data)
        {
            T Result= default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    // URL Absoluto
                    requestURI = BaseAddress + requestURI;
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add
                        (new MediaTypeWithQualityHeaderValue
                        ("application/json"));

                    var JSONData = JsonConvert.SerializeObject(data);
                    HttpResponseMessage Response =
                        await Client.PostAsync(requestURI,
                        new StringContent(JSONData.ToString(),
                        Encoding.UTF8, "application/json"));

                    var ResultWebAPI = await Response.Content.
                        ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<T>(ResultWebAPI);
                }
                catch (Exception ex)
                {

                   

                }
            }
            return Result; 
        }


        public async  Task<T> SendGet<T>(string requestURI)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    requestURI = BaseAddress + requestURI;

                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add
                        (new MediaTypeWithQualityHeaderValue("application/json"));

                    var ResultJSON = await Client.GetStringAsync(requestURI);
                    Result = JsonConvert.DeserializeObject<T>(ResultJSON);
                }
                catch (Exception)
                {

                    throw;
                }
                return Result;
            }
        }



        public Category CreateCategory(Category newCategory)
        {
            // HTTPClient
            throw new NotImplementedException();
        }

        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            return await SendPost<Product, Product>
                ("/api/nwind/createproduct", newProduct);
        }

        public Product CreateProduct(Product newProduct)
        {
            Product Result = null;
            Task.Run(async () => Result =
            await CreateProductAsync(newProduct)).Wait();
            return Result;
        }

        public bool DeleteCategory(int ID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> FilterProductsByCategoryIDAsync
            (int ID)
        {
            return await SendGet<List<Product>>
                ($"/api/nwind/FilterProductsByCategoryID/{ID}");
        }
        public List<Product> FilterProductsByCategoryID(int categoryID)
        {
            List<Product> Result = null;
            Task.Run(async () => Result = await
            FilterProductsByCategoryIDAsync(categoryID)).Wait();
            return Result;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await SendGet<List<Category>>
                ($"/api/nwind/GetCategories");
        }
        public List<Category> GetCategories()
        {
            List<Category> Result = null;
            Task.Run(async () => Result = await GetCategoriesAsync());
            return Result;
        }

        public async Task<Category> RetrieveCategoryByIDAsync(int ID)
        {
            return await SendGet<Category>
                ($"/api/nwind/RetrieveCategoryByID/{ID}");
        }
        public Category RetriveCategoryByID(int ID)
        {
            Category Result = null;
            Task.Run(async () => Result =
            await RetrieveCategoryByIDAsync(ID));
            return Result;
        }

        public async Task<Product> RetriveProductByIDAsync(int ID)
        {
            return await SendGet<Product>
                ($"/api/nwind/RetrieveProductByID/{ID}");
        }
        public Product RetriveProductByID(int ID)
        {
            Product Result = null;
            Task.Run(async () => Result = 
            await RetriveProductByIDAsync(ID)).Wait();
            return Result;
        }

        public async Task<bool> UpdateCategoryAsync
            (Category categoryToUpdate)
        {
            return await SendPost<bool, Category>
                ("api/nwind/UpdateCategory", categoryToUpdate);
        }
        public bool UpdateCategory(Category categoryToUpdate)
        {
            bool Result = false;
            Task.Run(async () => Result = await
            UpdateCategoryAsync(categoryToUpdate)).Wait();
            return Result;
        }
        public async Task<bool> UpdateProductAsync
           (Product productToUpdate)
        {
            return await SendPost<bool, Product>
                ("api/nwind/UpdateProduct", productToUpdate);
        }
        public bool UpdateProduct(Product productToUpdate)
        {
            bool Result = false;
            Task.Run(async () => Result = await
            UpdateProductAsync(productToUpdate)).Wait();
            return Result;
        }
    }
}
