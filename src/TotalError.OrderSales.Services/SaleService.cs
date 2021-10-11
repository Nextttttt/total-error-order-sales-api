using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Services
{
    public class SaleService : BaseService<SaleDto>, ISaleService
    {
        public SaleService(ISaleRepository saleRepository)
            :base(saleRepository)
        {

        }

        public override Task<SaleDto> CreateAsync(SaleDto dto)
        {
            return base.CreateAsync(dto);
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
