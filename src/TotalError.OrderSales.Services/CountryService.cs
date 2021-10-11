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
        public CountryService(ICountryRepository countryRepository)
            :base(countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public override async Task<CountryDto> CreateAsync(CountryDto dto)
        {
            var existingEntry = await _countryRepository.GetByNameAsync(dto.Name);

            if (existingEntry != null)
            {
                return existingEntry;
            }
            return await base.CreateAsync(dto);
        }

        public override Task<CountryDto> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);
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
