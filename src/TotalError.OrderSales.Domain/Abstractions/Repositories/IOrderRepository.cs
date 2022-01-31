using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Repositories
{
    public interface IOrderRepository : IBaseRepository<OrderDto>
    {
        Task<OrderSummeryDto> GetOrdersByCountryAsync(SummaryRequest request);

        Task<OrderSummeryDto> GetOrdersByRegionAsync(SummaryRequest request);

        Task<OrderSummeryDto> GetOrdersByOrderDateAsync(SummaryRequest request);

        bool IsDataRegistered(DateTime date);
    }
}
