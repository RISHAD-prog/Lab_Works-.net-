using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public  interface IRepo<CLASS,ID>
    {
         List<CLASS> Get();
         CLASS Get(ID id);
         void Create(CLASS Obj);
         void Update(CLASS Obj);

 
         void Delete(ID id);
}
}
