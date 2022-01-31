using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Data.Entities;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Data.Repositories
{
    public class OrderRepository : BaseRepository<OrderDto, OrderEntity>, IOrderRepository
    {

        public OrderRepository(TotalErrorDbContext dbContext ,IMapper mapper)
            :base(dbContext,mapper)
        {
          
        }

        public async Task<OrderSummeryDto> GetOrdersByCountryAsync(SummaryRequest request)
        {
            var entityList = entities.Where(o => o.CountryId == request.Id).Include(o => o.Country).Include(o => o.Region).Include(o => o.Sale);

            OrderSummeryDto orderSummery = new();

            if(request.GetTotalCosts)
            {
                orderSummery.TotalCosts = CalcTotal(entityList.Select(o => o.Sale.TotalCost));
            }

            if (request.GetTotalProfits)
            {
                orderSummery.TotalProfits = CalcTotal(entityList.Select(o => o.Sale.TotalProfit));
            }

            orderSummery.Orders = _mapper.Map<List<OrderDto>>(await entityList.ToListAsync());

            return orderSummery;
        }

        public async Task<OrderSummeryDto> GetOrdersByRegionAsync(SummaryRequest request)
        {
            var entityList = entities.Where(o => o.RegionId == request.Id).Include(o => o.Country).Include(o => o.Region).Include(o => o.Sale);

            OrderSummeryDto orderSummery = new();

            if (request.GetTotalCosts)
            {
                orderSummery.TotalCosts = CalcTotal(entityList.Select(o => o.Sale.TotalCost));
            }

            if (request.GetTotalProfits)
            {
                orderSummery.TotalProfits = CalcTotal(entityList.Select(o => o.Sale.TotalProfit));
            }

            orderSummery.Orders = _mapper.Map<List<OrderDto>>(await entityList.ToListAsync());

            return orderSummery;
        }

        public async Task<OrderSummeryDto> GetOrdersByOrderDateAsync(SummaryRequest request)
        {
            var entityList = entities.Where(o => o.OrderDate == request.Date).Include(o => o.Country).Include(o => o.Region).Include(o => o.Sale);

            OrderSummeryDto orderSummery = new();

            if (request.GetTotalCosts)
            {
                orderSummery.TotalCosts = CalcTotal(entityList.Select(o => o.Sale.TotalCost));
            }

            if (request.GetTotalProfits)
            {
                orderSummery.TotalProfits = CalcTotal(entityList.Select(o => o.Sale.TotalProfit));
            }

            orderSummery.Orders = _mapper.Map<List<OrderDto>>(await entityList.ToListAsync());

            return orderSummery;
        }

        public bool IsDataRegistered(DateTime date)
        {
            if(entities.Where(o => o.CreatedOn.Date == date.Date).Any())
            {
                return true;
            }

            return false;
        }

        private decimal CalcTotal(IQueryable<decimal> values)
        {
            return values.Sum();
        }
    }
}
