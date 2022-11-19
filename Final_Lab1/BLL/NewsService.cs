using BLL.DTO;
using DAL.DB;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsService
    {
        public static void Create(NewsDTO news)
        {
            new NewsRepo().Create(new News()
            {
                Id = news.Id,
                Title = news.Title,
                CategoryId = news.CategoryId,   
                Date=news.Date,

            });
        }
        public static List<NewsDTO> AllNews()
        {
            var repo=new NewsRepo().Get();
            var dto = new List<NewsDTO>();
            foreach(var item in repo)
            {
                dto.Add(new NewsDTO{
                    Id = item.Id,
                    Title=item.Title,
                    CategoryId=item.CategoryId, 
                    Date = item.Date,
                });
            }
            return dto;

        }
        public static NewsDTO NewsId(int id)
        {
            var repo = new NewsRepo().Get(id);
            var dto = new NewsDTO();
            dto.Id = repo.Id;
            dto.Title = repo.Title;
            dto.CategoryId = repo.CategoryId;
            dto.Date = repo.Date;
            return dto;
        }
        public static void Update(NewsDTO news)
        {

            new NewsRepo().Update(new News{
                Id = news.Id,
                Title=news.Title,
                CategoryId=news.CategoryId,
                Date=news.Date,
            });
        }
        public static void Delete(int id)
        {
            new NewsRepo().Delete(id);  
        }
    }
}
