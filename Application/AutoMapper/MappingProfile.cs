using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();

            CreateMap<Company, CompanyDTO>()
                .ForMember(dest => dest.Leader, opt => opt.MapFrom(src => src.Leader))
                .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members));
        }
    }
}