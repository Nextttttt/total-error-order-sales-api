using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Repositories
{
    public interface IItemRepository : IBaseRepository<ItemDto>
    {
        public Task<ItemDto> GetByTypeAsync(string type);
    }
}
