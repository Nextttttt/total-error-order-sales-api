using AutoMapper;
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
    public class OrderRepository : BaseRepository<OrderCsvDto, OrderEntity>, IOrderRepository
    {
        public OrderRepository(TotalErrorDbContext dbContext ,IMapper mapper)
            :base(dbContext,mapper)
        {
           
        }

        public override Task<OrderCsvDto> CreateAsync(OrderCsvDto dto)
        {
            _dbContext.Regions.AddAsync(_mapper.Map<RegionEntity>(dto.Country.Region));
            _dbContext.Countries.AddAsync(_mapper.Map<CountryEntity>(dto.Country));

            return base.CreateAsync(dto);
        }

        public override Task<OrderCsvDto> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);
        }

        public override Task UpdateAsync(OrderCsvDto dto)
        {
            return base.UpdateAsync(dto);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
}
