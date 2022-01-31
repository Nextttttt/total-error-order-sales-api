using AutoMapper;
using TotalError.OrderSales.Domain.Dtos;
using TotalError.OrderSales.Domain.Models;

namespace TotalError.OrderSales.Domain
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SummaryRequest, SummaryRequestModel>().ReverseMap();

            CreateMap<OrderCsvDto, OrderDto>()
                .ForMember(o => o.Id, options => options.Ignore())
                .ForMember(o => o.RegionName, options => options.MapFrom(o => o.Country.Region.Name))
                .ForMember(o => o.CreatedOn, options => options.Ignore());
            CreateMap<SaleCsvDto, SaleDto>()
                .ForMember(s => s.ItemType, options => options.MapFrom(o => o.Item.ItemType))
                .ForMember(s => s.ItemId, options => options.MapFrom(o => o.Item.Id));
            CreateMap<ItemCsvDto, ItemDto>()
                .ForMember(i => i.UnitCost, options => options.MapFrom(i => i.Cost))
                .ReverseMap();
            CreateMap<CountryCsvDto, CountryDto>()
                .ForMember(c => c.RegionId, options => options.MapFrom(o => o.Region.Id));
            CreateMap<RegionCsvDto, RegionDto>();
        }
    }
}
