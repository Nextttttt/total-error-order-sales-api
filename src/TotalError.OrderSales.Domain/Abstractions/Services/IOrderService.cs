using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;
using TotalError.OrderSales.Domain.Models;

namespace TotalError.OrderSales.Domain.Abstractions.Services
{
    public interface IOrderService : IBaseService<OrderDto>
    {
        Task<OrderSummeryDto> GetOrdersByCountryAsync(SummaryRequestModel model);

        Task<OrderSummeryDto> GetOrdersByRegionAsync(SummaryRequestModel model);

        Task<OrderSummeryDto> GetOrdersByOrderDateAsync(SummaryRequestModel model);

        bool IsDataRegistered(DateTime date);
    }
}
