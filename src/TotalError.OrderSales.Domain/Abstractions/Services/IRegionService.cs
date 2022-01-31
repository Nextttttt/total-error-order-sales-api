using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Services
{
    public interface IRegionService : IBaseService<RegionDto>
    {
        public Task<Guid> GetIdByNameAsync(string name);
    }
}
