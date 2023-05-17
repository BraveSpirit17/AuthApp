using AuthApp.Application.Dto;
using AuthApp.Core.Entities;
using AutoMapper;

namespace AuthApp.Application.Mapping;

public class DtoToModelProfile : Profile
{
    public DtoToModelProfile()
    {
        CreateMap<UserCredentialDto, ApplicationUser>();
    }
}