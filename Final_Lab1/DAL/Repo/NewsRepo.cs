using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class NewsRepo : IRepo<News, int>
    {
        public void Create(News Obj)
        {
            var db = new BBCEntities();
            db.News.Add(new News()
            {
                Id = Obj.Id,
                Title=Obj.Title,
                CategoryId=Obj.CategoryId,
                Date=Obj.Date,
            });
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db=new BBCEntities();
            var data=db.News.Find(id);
            var item=db.News.Remove(data);
            db.SaveChanges();
            
        }

        public List<News> Get()
        {
            var db=new BBCEntities();
            return db.News.ToList();    
        }

        public News Get(int id)
        {
            var db = new BBCEntities();
            var data = db.News.Find(id);
            return new News()
            {
                Id=data.Id,
                Title = data.Title,
                CategoryId = data.CategoryId,
                Date=data.Date,
            };
        }

        public void Update(News news)
        {           
            var db = new BBCEntities();
            var data = db.News.Find(news.Id);
            data.Id = news.Id;
            data.Date=news.Date;
            data.Title = news.Title;
            data.CategoryId=news.CategoryId;
            db.SaveChanges();
        }
    }
}
