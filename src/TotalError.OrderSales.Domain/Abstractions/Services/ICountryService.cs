using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Services
{
    public interface ICountryService : IBaseService<CountryDto>
    {
        public Task<Guid> GetIdByNameAsync(string name);
    }
}
