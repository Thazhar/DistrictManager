using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DistrictAPITest.Dtos;
using DistrictAPITest.Models;

namespace DistrictAPITest.Profiles
{
    public class DistrictsProfile : Profile
    {
        public DistrictsProfile()
        {
            //Map of Source -> Target
            CreateMap<District, DistrictsReadDto>();
            //Map of Target -> source (As we are mapping the program data into database data)
            CreateMap<DistrictsCreateDto, District>();
            CreateMap<DistrictsUpdateDto, District>();
            CreateMap<District, DistrictsUpdateDto>();
        }
    }
}
