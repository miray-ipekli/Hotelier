using AutoMapper;
using Hotelier.DtoLayer.Dtos.RoomDto;
using Hotelier.EntityLayer.Concrete;

namespace Hotelier.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<UpdateRoomDto, Room>().ReverseMap();

        }
    }
}
