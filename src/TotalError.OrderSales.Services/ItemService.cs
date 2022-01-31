using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Services
{
    public class ItemService : BaseService<ItemDto>, IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
            :base(itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public override async Task<ItemDto> CreateAsync(ItemDto dto)
        {
            var existingEntry =await _itemRepository.GetByTypeAsync(dto.ItemType);
            if(existingEntry != null && existingEntry.UnitCost == dto.UnitCost)
            {
                return existingEntry;
            }
            return await base.CreateAsync(dto);
        }

        public override Task<ItemDto> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);
        }

        public async Task<ItemDto> GetByTypeAsync(string type)
        {
            return await _itemRepository.GetByTypeAsync(type);
        }

        public async Task<Guid> GetIdByTypeAsync(string type)
        {
            return await _itemRepository.GetIdByTypeAsync(type);
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
