using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Data.Entities;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Data.Repositories
{
    public abstract class BaseRepository<TDto, TEntity> : IBaseRepository<TDto>
        where TDto : BaseDto
        where TEntity : BaseEntity
    {
        protected readonly TotalErrorDbContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> entities;

        protected BaseRepository(TotalErrorDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            entities = dbContext.Set<TEntity>();
        }

        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            dto.Id = Guid.NewGuid();
            TEntity entity = _mapper.Map<TEntity>(dto);

            await entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> GetByIdAsync(Guid id)
        {
            TEntity entity = await entities
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            var dto = _mapper.Map<TDto>(entity);

            return dto;
        }

        public virtual async Task UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            TEntity entity = await entities
               .FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
