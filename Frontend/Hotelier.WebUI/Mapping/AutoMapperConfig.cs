using AutoMapper;
using Hotelier.EntityLayer.Concrete;
using Hotelier.WebUI.Dtos.AppUserDto;
using Hotelier.WebUI.Dtos.ServiceDto;

namespace Hotelier.WebUI.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();
        }
    }
}
