using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DonorService
    {
        public static List<DonorDTO> Get()
        {
            var data = DataAccessFacctory.DonorDataAccess().GET();
            var config = new MapperConfiguration(cfg=>cfg.CreateMap<Donor,DonorDTO>());
            var mapper = new Mapper(config);
            var receive = mapper.Map<List<DonorDTO>>(data);
            return receive;
        }
        public static DonorDTO Get(int id)
        {
            var data = DataAccessFacctory.DonorDataAccess().GET(id);
            var config=new MapperConfiguration(cfg=>cfg.CreateMap<Donor,DonorDTO>());
            var mapper=new Mapper(config);
            var receieve=mapper.Map<DonorDTO>(data);
            return receieve;
        }
        public static DonorDTO Add(DonorDTO group)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Donor, DonorDTO>();
                cfg.CreateMap<DonorDTO, Donor>();
            });
            var mapper= new Mapper(config);
            var map = mapper.Map<Donor>(group);
            var send = DataAccessFacctory.DonorDataAccess().ADD(map);
            var redata=mapper.Map<DonorDTO>(send);
            return redata;
        }
    }
}
