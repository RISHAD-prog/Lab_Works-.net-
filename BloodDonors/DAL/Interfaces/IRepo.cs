using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS,ID,RESULT>
    {
        RESULT ADD(CLASS OBJ);
        bool REMOVE(ID id);
        List<CLASS> GET();
        CLASS GET(ID id);
        RESULT UPDATE(CLASS OBJ);
    }
}
