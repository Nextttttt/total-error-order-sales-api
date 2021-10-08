using AutoMapper;
using TotalError.OrderSales.Api.Models;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<LoginResponseDto, UserDto>().ReverseMap();
            CreateMap<RegisterModel, UserDto>().ReverseMap();
        }
    }
}
