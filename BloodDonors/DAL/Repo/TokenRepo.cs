using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        BloodDonateEntities db;
        public TokenRepo()
        {
            db = new BloodDonateEntities();
        }
        public Token ADD(Token OBJ)
        {
            db.Tokens.Add(OBJ);
            if (db.SaveChanges() > 0)
            {
                return OBJ;
            }
            return null;
        }

        public List<Token> GET()
        {
            throw new NotImplementedException();
        }

        public Token GET(string id)
        {
            return db.Tokens.FirstOrDefault(x=>x.TKey.Equals(id));
        }

        public bool REMOVE(string id)
        {
            throw new NotImplementedException();
        }

        public Token UPDATE(Token OBJ)
        {
            var find=db.Tokens.Find(OBJ.TKey);
            db.Entry(find).CurrentValues.SetValues(OBJ);
            if (db.SaveChanges() > 0)
            {
                return find;
            }
            return null;
        }
    }
}
