﻿using AutoMapper;
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
    public class RegionRepository : BaseRepository<RegionDto,RegionEntity>, IRegionRepository
    {
        public RegionRepository(TotalErrorDbContext dbContext, IMapper mapper)
            :base(dbContext, mapper)
        {

        }

        public async Task<RegionDto> GetByNameAsync(string name)
        {
            var entity = await _dbContext.Regions.Where(r => r.Name == name).FirstOrDefaultAsync();

            return _mapper.Map<RegionDto>(entity);
        }

        public async Task<Guid> GetIdByNameAsync(string name)
        {
            var entity = await _dbContext.Regions.Where(c => c.Name == name).FirstOrDefaultAsync();

            return entity.Id;
        }
    }
}
