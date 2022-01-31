using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Services
{
    public interface IItemService : IBaseService<ItemDto>
    {
        Task<ItemDto> GetByTypeAsync(string type);

        Task<Guid> GetIdByTypeAsync(string type);
    }
}
