using AutoMapper;
using TotalError.OrderSales.Data.Entities;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<OrderDto, OrderEntity>()
                .ForMember(o => o.OrderDate, options => options.MapFrom(o => o.Date))
                .ReverseMap();
            CreateMap<RegionDto, RegionEntity>().ReverseMap();
            CreateMap<CountryDto, CountryEntity>().ReverseMap();
            CreateMap<ItemDto, ItemEntity>().ReverseMap();
            CreateMap<SaleDto, SaleEntity>().ReverseMap();
            CreateMap<UserDto, UserEntity>().ReverseMap();
        }
    }
}
