using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;
using TotalError.OrderSales.Domain.Exceptions;

namespace TotalError.OrderSales.Services
{
    public class RegionService : BaseService<RegionDto>, IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        public RegionService(IRegionRepository regionRepository)
            :base(regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public override async Task<RegionDto> CreateAsync(RegionDto dto)
        {
            var existingEntry = await _regionRepository.GetByNameAsync(dto.Name);
            if(existingEntry != null)
            {
                return existingEntry;
            }
            return await base.CreateAsync(dto);
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
