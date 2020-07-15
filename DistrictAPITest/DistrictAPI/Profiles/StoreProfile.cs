using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DistrictAPITest.Dtos;
using DistrictAPITest.Models;

namespace DistrictAPITest.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            //Map of Source -> Target
            CreateMap<Store, StoreReadDto>();
            //Map of Target -> source (As we are mapping the program data into database data)
            CreateMap<StoreCreateDto, Store>();
            CreateMap<StoreUpdateDto, Store>();
            CreateMap<Store, StoreUpdateDto>();
        }
    }
}
