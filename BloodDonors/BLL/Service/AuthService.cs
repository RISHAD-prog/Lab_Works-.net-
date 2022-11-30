using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AuthService
    {
        public static TokenDTO Authenticate(String Username,String Password)
        {
            var match=DataAccessFacctory.AuthDataAccess().AUTHENTICATION(Username, Password);
            if (match != null)
            {
                var token=new Token();
                token.UserName = Username;
                token.CreationTime = DateTime.Now;
                token.ExpirationTime = null;
                token.TKey=Guid.NewGuid().ToString();
                var rttk = DataAccessFacctory.TokenDataAccess().ADD(token);
                if( rttk != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Token, TokenDTO>());
                    var mapper = new Mapper(config);
                    var map = mapper.Map<TokenDTO>(rttk);
                    return map;
                }
            }
            return null;
        }
        public static bool IsTokenValid(string token)
        {
            var tk=DataAccessFacctory.TokenDataAccess().GET(token);
            if(token != null)
            {
               if (tk.ExpirationTime == null)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
