using BLL.DTO;
using DAL.DB;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryService
    {
        public static void Create(CategoryDTO category)
        {
            

            new CategoryRepo().Create(new Category()
            {
                Id=category.Id,
                Name=category.Name,

            });
            
            
           
        }
        public static List<CategoryDTO> AllCategory()
        {
            var repo=new CategoryRepo().Get();
            var list = new List<CategoryDTO>();
            foreach (var item in repo)
            {
                list.Add(new CategoryDTO()
                {
                    Id=item.Id,
                    Name=item.Name
                });
            }
            return list;
            
        }
        public static CategoryDTO GetCategory(int id)
        {
            var repo = new CategoryRepo().Get(id);
            return new CategoryDTO()
            {
                Id = repo.Id,
                Name=repo.Name,
            };        
        }
    }
}
