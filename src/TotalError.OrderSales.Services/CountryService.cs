using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Services
{
    public class CountryService : BaseService<CountryDto>, ICountryService
    {
        public CountryService(ICountryRepository countryRepository)
            :base(countryRepository)
        {

        }

        public override Task<CountryDto> CreateAsync(CountryDto dto)
        {
            return base.CreateAsync(dto);
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
