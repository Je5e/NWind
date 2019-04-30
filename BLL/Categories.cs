using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
   public class Categories
    {
        public Category Create(Category newCategory)
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                newCategory = r.Create(newCategory);
            }
            return newCategory;
        }
        public Category RetrieveByID(int ID)
        {
            Category Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Retrieve<Category>(c => c.CategoryID == ID);
            }
            return Result;
        }

        public bool Update(Category categoryToUpdate)
        {
            bool Result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Update(categoryToUpdate);
            }
            return Result;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            var Category = RetrieveByID(ID);
            
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Delete(Category);
            }

            return Result;
        }
        public List<Category> GetCategories()
        {
            List<Category> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result =
                    r.Filter<Category>
                    (c => true);
            }
            return Result;
        }







    }
}
