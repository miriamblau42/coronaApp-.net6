using AutoMapper;
using EpedimiologicReport.Services.Dtos;
using EpedimiologicReport.Dal.Models;


namespace EpedimiologicReport.Services
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserLoginDto>()
                .ForMember(des => des.Name,opts => opts.MapFrom(user => user.Name))
                .ForMember(des => des.Password, opts => opts.MapFrom(user => user.Password)).ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}
