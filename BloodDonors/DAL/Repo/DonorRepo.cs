using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class DonorRepo : IRepo<Donor, int, Donor>
    {
        BloodDonateEntities db;
        internal DonorRepo()
        {
            db = new BloodDonateEntities();
        }
        public Donor ADD(Donor OBJ)
        {
            db.Donors.Add(OBJ);
            db.SaveChanges();
            return OBJ;
        }

        public List<Donor> GET()
        {
            return db.Donors.ToList();
        }

        public Donor GET(int id)
        {
            return db.Donors.Find(id);
            
        }

        public bool REMOVE(int id)
        {
            db.Donors.Remove( db.Donors.Find(id));
            db.SaveChanges();
            return db.SaveChanges()>0;         
        }

        public Donor UPDATE(Donor OBJ)
        {
            var find=db.Donors.Find(OBJ.Id);
            db.Entry(find).CurrentValues.SetValues(OBJ);
            if (db.SaveChanges() > 0)
            {
                return OBJ;
            }
            return null;
        }
    }
}
