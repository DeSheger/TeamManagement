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
            
            CreateMap<Group, GroupDTO>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
                .ForMember(dest => dest.Leader, opt => opt.MapFrom(src => src.Leader))
                .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members));
            
            CreateMap<Activity, ActivityDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Group.Id))
                .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members));
        }
    }
}