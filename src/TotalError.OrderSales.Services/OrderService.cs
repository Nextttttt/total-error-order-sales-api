using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;
using TotalError.OrderSales.Domain.Models;

namespace TotalError.OrderSales.Services
{
    public class OrderService : BaseService<OrderDto>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICountryService _countryService;
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, ICountryService countryService, IRegionService regionService, IMapper mapper)
            :base(orderRepository)
        {
            _orderRepository = orderRepository;
            _countryService = countryService;
            _regionService = regionService;
            _mapper = mapper;
        }

        public bool IsDataRegistered(DateTime date)
        {
            return _orderRepository.IsDataRegistered(date);
        }

        public override async Task<OrderDto> CreateAsync(OrderDto dto)
        {
            dto.CountryId = await _countryService.GetIdByNameAsync(dto.CountryName);
            dto.RegionId = await _regionService.GetIdByNameAsync(dto.RegionName);
            return await base.CreateAsync(dto);
        }

        public override Task<OrderDto> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);
        }

        public async Task<OrderSummeryDto> GetOrdersByCountryAsync(SummaryRequestModel model)
        {
            SummaryRequest request = new SummaryRequest();
            request = _mapper.Map<SummaryRequest>(model);
            request.Id = await _countryService.GetIdByNameAsync(model.name);
            return await _orderRepository.GetOrdersByCountryAsync(request);
        }

        public async Task<OrderSummeryDto> GetOrdersByRegionAsync(SummaryRequestModel model)
        {
            SummaryRequest request = new SummaryRequest();
            request = _mapper.Map<SummaryRequest>(model);
            request.Id = await _regionService.GetIdByNameAsync(model.name);
            return await _orderRepository.GetOrdersByRegionAsync(request);
        }

        public async Task<OrderSummeryDto> GetOrdersByOrderDateAsync(SummaryRequestModel model)
        {
            SummaryRequest request = new SummaryRequest();
            request = _mapper.Map<SummaryRequest>(model);
            request.Date = model.Date;
            return await _orderRepository.GetOrdersByOrderDateAsync(request);
        }

        public override Task UpdateAsync(OrderDto dto)
        {
            return base.UpdateAsync(dto);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
}
