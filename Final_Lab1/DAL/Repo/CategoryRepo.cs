using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CategoryRepo : IRepo<Category, int>
    {
        public void Create(Category Obj)
        {
            var db=new BBCEntities();
            db.Categories.Add(new Category()
            {
                Id = Obj.Id,
                Name = Obj.Name,    
            });
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> Get()
        {
           var db= new BBCEntities();
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            var db = new BBCEntities();
            var data = db.Categories.Find(id);
            return new Category()
            {
                Id=data.Id,
                Name=data.Name
            };
        }

        public void Update(Category OBJ)
        {
            throw new NotImplementedException();
        }
    }
}
