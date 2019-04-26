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






    }
}
