﻿using DAL.DB;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFacctory
    {
        public static IRepo<Group,int,bool> GroupDataAccess()
        {
            return new GroupRepo();
        }
        public static IRepo<Donor, int, Donor> DonorDataAccess()
        {
            return new DonorRepo();
        }
        public static IRepo<User,String,User> UserDataAccess()
        {
            return new UserRepo();
        }
        public static URepo AuthDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Token,string,Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
    }
}
