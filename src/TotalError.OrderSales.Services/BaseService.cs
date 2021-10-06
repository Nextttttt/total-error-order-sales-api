using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Services
{
    public abstract class BaseService<TDto> : IBaseService<TDto>
        where TDto : BaseDto
    {
        protected readonly IBaseRepository<TDto> _baseRepository;
        public BaseService(IBaseRepository<TDto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<TDto> GetByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            return await _baseRepository.CreateAsync(dto);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public virtual async Task UpdateAsync(TDto dto)
        {
            await _baseRepository.UpdateAsync(dto);
        }
    }
}
