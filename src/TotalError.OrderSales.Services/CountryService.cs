using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;
using TotalError.OrderSales.Domain.Exceptions;

namespace TotalError.OrderSales.Services
{
    public class CountryService : BaseService<CountryDto>, ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IRegionService _regionService;
        public CountryService(ICountryRepository countryRepository, IRegionService regionService)
            :base(countryRepository)
        {
            _countryRepository = countryRepository;
            _regionService = regionService;
        }

        public override async Task<CountryDto> CreateAsync(CountryDto dto)
        {
            var existingEntry = await _countryRepository.GetByNameAsync(dto.Name);

            if (existingEntry != null)
            {
                return existingEntry;
            }
            dto.RegionId = await _regionService.GetIdByNameAsync(dto.RegionName);
            return await base.CreateAsync(dto);
        }

        public override Task<CountryDto> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);
        }

        public async Task<Guid> GetIdByNameAsync(string name)
        {
            return await _countryRepository.GetIdByNameAsync(name);
        }

        public override Task UpdateAsync(CountryDto dto)
        {
            return base.UpdateAsync(dto);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
}
