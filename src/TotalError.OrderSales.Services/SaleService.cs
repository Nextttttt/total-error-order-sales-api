using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Services
{
    public class SaleService : BaseService<SaleCsvDto>, ISaleService
    {
        public SaleService(ISaleRepository saleRepository)
            :base(saleRepository)
        {

        }

        public override Task<SaleCsvDto> CreateAsync(SaleCsvDto dto)
        {
            return base.CreateAsync(dto);
        }

        public override Task<SaleCsvDto> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);   
        }

        public override Task UpdateAsync(SaleCsvDto dto)
        {
            return base.UpdateAsync(dto);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
}
