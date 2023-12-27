using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
            .ReverseMap();

            CreateMap<User, SessionDto>();

            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.Leader, opt => opt.MapFrom(src => src.Leader))
                .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members))
                .ReverseMap();

            
            CreateMap<Group, GroupDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
                .ForMember(dest => dest.Leader, opt => opt.MapFrom(src => src.Leader))
                .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members))
                .ReverseMap();

            CreateMap<Activity, ActivityDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group))
                .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members))
                .ReverseMap();

        }
    }
}