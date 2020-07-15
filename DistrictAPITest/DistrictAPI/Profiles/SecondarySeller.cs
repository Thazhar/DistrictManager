using AutoMapper;
using DistrictAPITest.Dtos;

namespace DistrictAPITest.Profiles
{
    public class SecondarySeller : Profile
    {
        public SecondarySeller()
        {
            //Map of Source -> Target
            CreateMap<SecondarySeller, SecondarySellerReadDto>();
            //Map of Target -> source (As we are mapping the program data into database data)
            CreateMap<SecondarySellerCreateDto, SecondarySeller>();
            CreateMap<SecondarySeller, SecondarySellerCreateDto>();
        }
    }
}
