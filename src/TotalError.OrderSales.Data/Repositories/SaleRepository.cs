using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TotalError.OrderSales.Data.Entities;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Data.Repositories
{
    public class SaleRepository : BaseRepository<SaleDto,SaleEntity>, ISaleRepository
    {
        public SaleRepository(TotalErrorDbContext dbContext, IMapper mapper)
            :base(dbContext, mapper)
        {

        }
    }
}
