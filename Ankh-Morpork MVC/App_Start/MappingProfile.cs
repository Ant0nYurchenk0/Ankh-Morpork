using Ankh_Morpork_MVC.Dtos;
using Ankh_Morpork_MVC.Models;
using AutoMapper;

namespace Ankh_Morpork_MVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Event, EventDto>();
            Mapper.CreateMap<EventDto, Event>();
        }
    }
}