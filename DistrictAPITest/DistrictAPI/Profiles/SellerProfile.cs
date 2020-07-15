using AutoMapper;
using DistrictAPITest.Dtos;
using DistrictAPITest.Models;

namespace DistrictAPITest.Profiles
{
    public class SellerProfile : Profile
    {
        public SellerProfile()
        {
            //Map of Source -> Target
            CreateMap<Seller, SellerReadDto>();
            //Map of Target -> source (As we are mapping the program data into database data)
            CreateMap<SellerCreateDto, Seller>();
            CreateMap<SellerUpdateDto, Seller>();
            CreateMap<Seller, SellerUpdateDto>();
        }
    }
}
