using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TotalError.OrderSales.Data.Entities;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Data.Repositories
{
    public class ItemRepository : BaseRepository<ItemDto, ItemEntity>, IItemRepository
    {
        public ItemRepository(TotalErrorDbContext dbContext, IMapper mapper)
            :base(dbContext,mapper)
        {

        }

        public async Task<ItemDto> GetByTypeAsync(string type)
        {
            var entity = await _dbContext.Items.Where(i => i.ItemType == type).FirstOrDefaultAsync();

            return _mapper.Map<ItemDto>(entity);
        }
    }
}
