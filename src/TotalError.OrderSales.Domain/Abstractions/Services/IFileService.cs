using System.Collections.Generic;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Services
{
    public interface IFileService
    {
        public IEnumerable<OrderDto> ReadFile();
    }
}
