using DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface URepo
    {
        User AUTHENTICATION(string username, String password);
    }
}
