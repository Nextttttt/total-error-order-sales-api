using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Services
{
    public class SaleService : BaseService<SaleDto>, ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IItemService _itemService;
        public SaleService(ISaleRepository saleRepository, IItemService itemService)
            :base(saleRepository)
        {
            _saleRepository = saleRepository;
            _itemService = itemService;
        }

        public override async Task<SaleDto> CreateAsync(SaleDto dto)
        {
            dto.ItemId =await _itemService.GetIdByTypeAsync(dto.ItemType);
            return await _saleRepository.CreateAsync(dto);
        }

        public override Task<SaleDto> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);   
        }

        public override Task UpdateAsync(SaleDto dto)
        {
            return base.UpdateAsync(dto);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
}
