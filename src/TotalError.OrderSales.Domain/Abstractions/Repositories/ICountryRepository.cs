using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Repositories
{
    public interface ICountryRepository : IBaseRepository<CountryDto>
    {
        public Task<CountryDto> GetByNameAsync(string name);

        public Task<Guid> GetIdByNameAsync(string name);
    }
}
