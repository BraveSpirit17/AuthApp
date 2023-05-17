using AuthApp.Application.Dto;
using AuthApp.Core.Entities;
using AutoMapper;

namespace AuthApp.Application.Mapping;

public class ModelToDtoProfile : Profile
{
    public ModelToDtoProfile()
    {
        CreateMap<ApplicationUser, UserDto>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName} {src.MiddleName}"));
    }
}