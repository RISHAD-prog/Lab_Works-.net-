using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IRepo<User, String, User>,URepo
    {
        BloodDonateEntities db;
        public UserRepo()
        {
            db = new BloodDonateEntities();
        }
        public User ADD(User OBJ)
        {
            db.Users.Add(OBJ);
            if (db.SaveChanges() > 0)
            {
                return OBJ;
            }
            return null;
        }

        public User AUTHENTICATION(string username, string password)
        {
            var obj=db.Users.FirstOrDefault(x=>x.UserName==username && x.Password==password);
            return obj;
        }

        public List<User> GET()
        {
            throw new NotImplementedException();
        }

        public User GET(string id)
        {
            throw new NotImplementedException();
        }

        public bool REMOVE(String UName)
        {
            throw new NotImplementedException();
        }

        public User UPDATE(User OBJ)
        {
            throw new NotImplementedException();
        }
    }
}
