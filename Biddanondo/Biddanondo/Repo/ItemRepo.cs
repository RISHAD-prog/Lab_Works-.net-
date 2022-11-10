using Biddanondo.Dbs;
using Biddanondo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biddanondo.Repo
{
    public class ItemRepo
    {
        public static List<ItemModel> Get()
        {
            var db = new BiddanondoEntities();
            var dbr = new List<ItemModel>();
            foreach (var item in db.Items)
            {
                dbr.Add(new ItemModel()
                {
                    Id = item.Id,
                    RestaurantId = item.RestaurantId,
                    EmployeeId = item.EmployeeId,
                    RestaurantName = item.RestaurantName,
                    EmployeeName = item.EmployeeName,
                    Location = item.Location,
                });
            }
            return dbr;
        }
        public static ItemModel Get(int id)
        {
            var db = new BiddanondoEntities();
            var model = db.Items.Find(id);
            return new ItemModel()
            {
                Id = model.Id,
                RestaurantId= model.RestaurantId,
                EmployeeId= model.EmployeeId,
                EmployeeName = model.EmployeeName,  
                RestaurantName= model.RestaurantName,
                Location = model.Location,
            };

        }
        public static void Create(ItemModel employee)
        {
            var db = new BiddanondoEntities();
            db.Items.Add(new Item()
            {
                Id = employee.Id,
                RestaurantId=employee.RestaurantId,
                EmployeeId= employee.EmployeeId,
                RestaurantName=employee.RestaurantName,
                EmployeeName = employee.EmployeeName,
                Location=employee.Location,
            });

            db.SaveChanges();


        }
    }
}