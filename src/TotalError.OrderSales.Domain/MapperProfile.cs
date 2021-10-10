﻿using AutoMapper;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<OrderCsvDto, OrderDto>()
                .ForMember(o => o.CountryId, options => options.MapFrom(o => o.Country.Id))
                .ForMember(o => o.SaleId, options => options.MapFrom(o => o.Sale.Id));
            CreateMap<OrderCsvDto, SaleDto>()
                .ForMember(s => s.ItemId, options => options.MapFrom(o => o.Sale.Item.Id));
            CreateMap<OrderCsvDto, CountryDto>()
                .ForMember(c => c.RegionId, options => options.MapFrom(o => o.Id));
            CreateMap<RegionCsvDto, RegionDto>();
        }
    }
}
