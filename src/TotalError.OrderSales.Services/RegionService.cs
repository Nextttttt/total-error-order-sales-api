using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Services
{
    public class RegionService : BaseService<RegionDto>, IRegionService
    {
        public RegionService(IRegionRepository regionRepository)
            :base(regionRepository)
        {

        }

        public override Task<RegionDto> CreateAsync(RegionDto dto)
        {
            return base.CreateAsync(dto);
        }

        public override Task<RegionDto> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);
        }

        public override Task UpdateAsync(RegionDto dto)
        {
            return base.UpdateAsync(dto);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
}
