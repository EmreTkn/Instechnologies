using API.Dtos.Response;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            //Response maps

            CreateMap<Car, CarDto>()
                .ForMember(dst => dst.HeadlightsStatus,
                    opt => opt.MapFrom(src => src.HeadLights ? "Headlights on" : "Headlights of"))
                .ForMember(dst => dst.Color, opt => opt.MapFrom(src => src.Color.Name));

            CreateMap<Bus, BusDto>()
                .ForMember(dst => dst.Color, opt => opt.MapFrom(src => src.Color.Name));

            CreateMap<Boat, BoatDto>()
                .ForMember(dst => dst.Color, opt => opt.MapFrom(src => src.Color.Name));

            //

            //Request maps

            //
        }
    }
}
