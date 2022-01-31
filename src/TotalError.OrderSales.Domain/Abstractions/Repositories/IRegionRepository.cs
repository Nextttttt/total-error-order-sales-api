using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Repositories
{
    public interface IRegionRepository : IBaseRepository<RegionDto>
    {
        public Task<RegionDto> GetByNameAsync(string name);

        public Task<Guid> GetIdByNameAsync(string name);
    }
}
