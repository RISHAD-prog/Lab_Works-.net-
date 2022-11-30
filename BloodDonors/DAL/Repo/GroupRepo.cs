using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class GroupRepo : IRepo<Group, int, bool>
    {
        BloodDonateEntities db;
        internal GroupRepo()
        {
            db = new BloodDonateEntities();
        }
        public bool ADD(Group OBJ)
        {
            db.Groups.Add(OBJ);
            return db.SaveChanges()>0;

        }

        public List<Group> GET()
        {
            
            return db.Groups.ToList();
        }

        public Group GET(int id)
        {
            return db.Groups.Find(id);
        }

        public bool REMOVE(int id)
        {
            db.Groups.Remove(db.Groups.Find(id));
            return db.SaveChanges()>0;
        }

        public bool UPDATE(Group OBJ)
        {
            var find = db.Groups.Find(OBJ.Id);
            db.Entry(find).CurrentValues.SetValues(OBJ);
            return db.SaveChanges() > 0;
        }
    }
}
