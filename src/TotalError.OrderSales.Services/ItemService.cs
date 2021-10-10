using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Services
{
    public class ItemService : BaseService<ItemDto>, IItemService
    {
        public ItemService(IItemRepository itemRepository)
            :base(itemRepository)
        {

        }

        public override Task<ItemDto> CreateAsync(ItemDto dto)
        {
            return base.CreateAsync(dto);
        }

        public override Task<ItemDto> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);
        }

        public override Task UpdateAsync(ItemDto dto)
        {
            return base.UpdateAsync(dto);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }

}
