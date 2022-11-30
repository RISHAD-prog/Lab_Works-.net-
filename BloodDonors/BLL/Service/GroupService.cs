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
    public class GroupService
    {
        public static List<GroupDTO> Get()
        {
            var groups=DataAccessFacctory.GroupDataAccess().GET();
            var config = new MapperConfiguration(cfg=>cfg.CreateMap<Group,GroupDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<GroupDTO>>(groups);
            return data;
        }
        public static GroupDTO Get(int id)
        {
            var data = DataAccessFacctory.GroupDataAccess().GET(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>());
            var mapper = new Mapper(config);
            var group = mapper.Map<GroupDTO>(data);
            return group;
        }
        public static bool ADD(GroupDTO group)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GroupDTO, Group>();
                cfg.CreateMap<Group, GroupDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Group>(group);
            var send = DataAccessFacctory.GroupDataAccess().ADD(data);
            return send;
        }
    }
}
