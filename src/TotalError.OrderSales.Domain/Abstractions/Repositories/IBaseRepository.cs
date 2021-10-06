using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Repositories
{
    public interface IBaseRepository<TDto>
        where TDto : BaseDto
    {
        public Task<TDto> GetByIdAsync(Guid id);

        public Task<TDto> CreateAsync(TDto dto);

        public Task DeleteAsync(Guid id);

        public Task UpdateAsync(TDto dto);
    }
}
